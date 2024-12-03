using System.Collections.Generic;
using System.Threading.Tasks;
using TrueChat.BlazorApp.Client.Models;

namespace TrueChat.BlazorApp.Client.Clients;

public interface IChatClient
{
    public Task<IEnumerable<ChatMessage>> GetMessagesAsync();
    
    public Task<ChatMessage> AddMessageAsync(ChatMessage message);
}