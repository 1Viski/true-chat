using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Options;
using DocumentSentiment = TrueChat.Core.Enums.DocumentSentiment;

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

    public async Task<DocumentSentiment> GetSentimentAsync(string document, CancellationToken cancellationToken = default)
    {
        var response = await _client.AnalyzeSentimentAsync(document, cancellationToken: cancellationToken);
        var documentSentiment = Enum.Parse<DocumentSentiment>(response.Value.Sentiment.ToString());
        return documentSentiment;
    }
}