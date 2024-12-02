using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Interfaces;

namespace TrueChat.Infrastructure.Context;

public class AppDbContextFactory<TContext> : IAppDbContextFactory where TContext : DbContext, IAppDbContext
{
    private readonly IDbContextFactory<TrueChatDbContext> _dbContextFactory;

    public AppDbContextFactory(IDbContextFactory<TrueChatDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IAppDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
    }
}