using TrueChat.BlazorApp.Client.Enums;

namespace TrueChat.BlazorApp.Client.Services;

public interface IAnalyticsService
{
    public Task<DocumentSentiment> GetSentiment(string document);
}