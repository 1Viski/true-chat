using TrueChat.BlazorApp.Client.Enums;

namespace TrueChat.BlazorApp.Client.Services;

public interface IAnalyticsService
{
    public Task<SentimentLabel> GetSentimentAsync(string document);
}