using System.Text;
using System.Text.Json;
using TrueChat.BlazorApp.Client.Models;

namespace TrueChat.BlazorApp.Client.Clients;

public class ChatClient : IChatClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ChatClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7145/");
        
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<IEnumerable<ChatMessage>> GetMessagesAsync()
    {
        var response = await _httpClient.GetAsync("/api/v1/chat-messages");
        response.EnsureSuccessStatusCode();
        await using var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<IEnumerable<ChatMessage>>(stream, _jsonSerializerOptions);
        return result ?? [];
    }

    public async Task<ChatMessage> AddMessageAsync(ChatMessage message)
    {
        var contentRequest = new StringContent(
            JsonSerializer.Serialize(message, _jsonSerializerOptions), 
            Encoding.UTF8, 
            "application/json");
        
        var response = await _httpClient.PostAsync("/api/v1/chat-messages", contentRequest);
        response.EnsureSuccessStatusCode();
        await using var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<ChatMessage>(stream, _jsonSerializerOptions);
        return result ?? throw new NullReferenceException();
    }
}