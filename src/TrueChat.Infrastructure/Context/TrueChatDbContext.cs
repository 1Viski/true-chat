using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Enums;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Models;

namespace TrueChat.Infrastructure.Context;

/// <summary>
/// Database context inherit of <see cref="DbContext"/>, implements <see cref="IAppDbContext"/>
/// </summary>
public class TrueChatDbContext : DbContext, IAppDbContext
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options">Base options</param>
    public TrueChatDbContext(DbContextOptions options) : base(options) { }
    
    /// <summary>
    /// DbSet property for messages
    /// </summary>
    public DbSet<ChatMessage> ChatMessages { get; set; }
    
    /// <summary>
    /// Override method OnModelCreating for fluent design
    /// </summary>
    /// <param name="modelBuilder"><see cref="ModelBuilder"/></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasIndex(x => x.Nickname);

            entity
                .Property(x => x.Nickname)
                .HasMaxLength(50);

            entity
                .Property(x => x.Text)
                .HasMaxLength(500);
            
            entity
                .Property(x => x.Id)
                .HasConversion(
                    x => x.ToString(),
                    x => Ulid.Parse(x));
        });
    }
}