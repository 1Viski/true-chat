using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Models;

namespace TrueChat.Core.Interfaces;

public interface IAppDbContext : IAsyncDisposable, IDisposable
{
    public DbSet<ChatMessage> ChatMessages { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
}