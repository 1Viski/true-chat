using Microsoft.EntityFrameworkCore;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Models;

namespace TrueChat.Core.Services;

public class ChatService : IChatService
{
    private readonly IAppDbContextFactory _dbContextFactory;

    public ChatService(IAppDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<ChatMessage>> GetMessagesAsync(CancellationToken cancellationToken = default)
    {
        var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        
        var messages = await context.ChatMessages
            .Select(x => x)
            .ToListAsync(cancellationToken);
        
        return messages.Count == 0 ? [] : messages;
    }

    public async Task AddMessageAsync(ChatMessage message, CancellationToken cancellationToken = default)
    {
        var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        await context.ChatMessages.AddAsync(message, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}