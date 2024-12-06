using TrueChat.BlazorApp.Client.Clients;
using TrueChat.BlazorApp.Client.Enums;

namespace TrueChat.BlazorApp.Client.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly IAnalyticsClient _client;

    public AnalyticsService(IAnalyticsClient client)
    {
        _client = client;
    }

    public async Task<SentimentLabel> GetSentimentAsync(string document)
    {
        return await _client.GeSentimentAsync(document);
    }
}