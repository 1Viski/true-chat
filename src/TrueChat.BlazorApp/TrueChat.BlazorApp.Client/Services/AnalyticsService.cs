using TrueChat.BlazorApp.Client.Clients;
using DocumentSentiment = TrueChat.BlazorApp.Client.Enums.DocumentSentiment;

namespace TrueChat.BlazorApp.Client.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly IAnalyticsClient _client;

    public AnalyticsService(IAnalyticsClient client)
    {
        _client = client;
    }

    public async Task<DocumentSentiment> GetSentiment(string document)
    {
        return await _client.GeSentimentAsync(document);
    }
}