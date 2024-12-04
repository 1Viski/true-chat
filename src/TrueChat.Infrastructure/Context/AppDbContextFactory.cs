using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Interfaces;

namespace TrueChat.Infrastructure.Context;

/// <summary>
/// Database context factory
/// </summary>
/// <typeparam name="TContext">The type of inherits <see cref="DbContext"/> and implements <see cref="IAppDbContext"/></typeparam>
public class AppDbContextFactory<TContext> : IAppDbContextFactory where TContext : DbContext, IAppDbContext
{
    /// <summary>
    /// read-only field <see cref="IDbContextFactory{TContext}"/>, TContext: <see cref="TrueChatDbContext"/>
    /// </summary>
    private readonly IDbContextFactory<TrueChatDbContext> _dbContextFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContextFactory"><see cref="IDbContextFactory{TContext}"/>, TContext: <see cref="TrueChatDbContext"/></param>
    public AppDbContextFactory(IDbContextFactory<TrueChatDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    /// <summary>
    /// Create database context
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Database context instance of <see cref="IAppDbContext"/></returns>
    public async Task<IAppDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
    }
}