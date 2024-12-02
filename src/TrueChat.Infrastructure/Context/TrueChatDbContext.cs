using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Models;

namespace TrueChat.Infrastructure.Context;

/// <summary>
/// Database context
/// </summary>
public class TrueChatDbContext : DbContext, IAppDbContext
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options">Send to base options</param>
    public TrueChatDbContext(DbContextOptions options) : base(options) { }
    
    /// <summary>
    /// DbSet property for messages
    /// </summary>
    public DbSet<ChatMessage> ChatMessages { get; set; }
    
    /// <summary>
    /// Override method OnModelCreating for fluent design
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(x => x.Id);
            
            entity
                .Property(x => x.Id)
                .HasConversion(
                    x => x.ToString(),
                    x => Ulid.Parse(x));

            entity.HasIndex(x => x.Nickname);
        });
    }
}