namespace TrueChat.Core.Interfaces;

public interface IAppDbContextFactory
{
    public Task<IAppDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default);
}