using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Models;

namespace TrueChat.Core.Services;

/// <summary>
/// Service implements <see cref="IChatService"/>
/// </summary>
public class ChatService : IChatService
{
    /// <summary>
    /// read-only field <see cref="IAppDbContextFactory"/>
    /// </summary>
    private readonly IAppDbContextFactory _dbContextFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContextFactory">Instance of <see cref="IAppDbContextFactory"/></param>
    public ChatService(IAppDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        
    }

    /// <summary>
    /// Implements method
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/></returns>
    public async Task<IEnumerable<ChatMessage>> GetMessagesAsync(CancellationToken cancellationToken = default)
    {
        var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        
        var messages = await context.ChatMessages
            .Select(x => x)
            .ToListAsync(cancellationToken);
        
        return messages.Count == 0 ? [] : messages;
    }

    /// <summary>
    /// Implements method
    /// </summary>
    /// <param name="message">Instance of <see cref="ChatMessage"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    public async Task AddMessageAsync(ChatMessage message, CancellationToken cancellationToken = default)
    {
        var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        message.Id = Ulid.NewUlid();
        await context.ChatMessages.AddAsync(message, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}