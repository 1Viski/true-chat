using TrueChat.Core.Enums;

namespace TrueChat.Core.Interfaces;

public interface IAnalyticsService
{
    public Task<DocumentSentiment> GetSentimentAsync(string document, CancellationToken cancellationToken = default);
}