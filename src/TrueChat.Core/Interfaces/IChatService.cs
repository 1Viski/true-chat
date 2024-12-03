using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrueChat.Core.Models;

namespace TrueChat.Core.Interfaces;

public interface IChatService
{
    public Task<IEnumerable<ChatMessage>> GetMessagesAsync(CancellationToken cancellationToken = default);
    
    public Task AddMessageAsync(ChatMessage message, CancellationToken cancellationToken = default);
}