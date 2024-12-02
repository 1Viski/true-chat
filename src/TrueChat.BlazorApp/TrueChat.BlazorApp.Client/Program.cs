using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TrueChat.BlazorApp.Client.Clients;
using TrueChat.BlazorApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<IChatClient, ChatClient>();
builder.Services.AddScoped<IChatService, ChatService>();

await builder.Build().RunAsync();