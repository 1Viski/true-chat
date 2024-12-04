using TrueChat.BlazorApp.Client.Enums;

namespace TrueChat.BlazorApp.Client.Clients;

public interface IAnalyticsClient
{
    public Task<DocumentSentiment> GeSentimentAsync(string document);
}