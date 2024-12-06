using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using TrueChat.Core.Enums;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Options;

namespace TrueChat.Core.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly TextAnalyticsClient _client;
    
    public AnalyticsService(IOptions<TextAnalyticsOptions> options)
    {
        _client = new TextAnalyticsClient(
            new Uri(options.Value.Endpoint!), 
            new AzureKeyCredential(options.Value.Key1!));
    }

    public async Task<SentimentLabel> GetSentimentAsync(string document, CancellationToken cancellationToken = default)
    {
        var response = await _client.AnalyzeSentimentAsync(document, cancellationToken: cancellationToken);
        var sentiment = Enum.Parse<SentimentLabel>(response.Value.Sentiment.ToString());
        return sentiment;
    }
}