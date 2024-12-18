using System.Text;
using System.Text.Json;
using TrueChat.BlazorApp.Client.Enums;
using TrueChat.BlazorApp.Client.Models;

namespace TrueChat.BlazorApp.Client.Clients;

public class AnalyticsClient : IAnalyticsClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public AnalyticsClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(configuration.GetValue<string>("BaseAddress")!);
        
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<SentimentLabel> GeSentimentAsync(string document)
    {
        var plainText = new PlainText
        {
            Value = document
        };
        
        var contentRequest = new StringContent(
            JsonSerializer.Serialize(plainText, _jsonSerializerOptions), 
            Encoding.UTF8, 
            "application/json");
        
        var response = await _httpClient.PostAsync("/api/v1/text-sentiment", contentRequest);
        response.EnsureSuccessStatusCode();
        await using var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<PlainText>(stream, _jsonSerializerOptions);
        return Enum.Parse<SentimentLabel>(result!.Value!);
    }
}