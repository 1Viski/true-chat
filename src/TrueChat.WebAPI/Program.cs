using Microsoft.AspNetCore.ResponseCompression;
using TrueChat.Core;
using TrueChat.Infrastructure;
using TrueChat.WebAPI.Endpoints;
using TrueChat.WebAPI.Hubs;
using TrueChat.WebAPI.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR().AddAzureSignalR();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore();

builder.Services.ConfigureOptions<TextAnalyticsOptionsSetup>();

builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/octet-stream"]);
});

builder.Services.AddCors(options => 
    options.AddPolicy("TrueChatClient", policyBuilder =>
        policyBuilder.WithOrigins("https://localhost:7165", "https://wa-true-chat-client.azurewebsites.net/")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TrueChatClient");
app.UseResponseCompression();

app.MapHub<ChatHub>("chat-hub");
app.MapChatEndpoints();

app.Run();