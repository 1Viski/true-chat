using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TrueChat.BlazorApp.Client.Clients;
using TrueChat.BlazorApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.Services.AddHttpClient<IChatClient, ChatClient>();
builder.Services.AddHttpClient<IAnalyticsClient, AnalyticsClient>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

await builder.Build().RunAsync();