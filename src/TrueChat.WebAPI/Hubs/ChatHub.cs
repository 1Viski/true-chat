using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TrueChat.Core.Dtos;
using TrueChat.Core.Interfaces;

namespace TrueChat.WebAPI.Hubs;

/// <summary>
/// Strongly typed <see cref="Hub"/> for type of client <see cref="IChatClient"/> 
/// </summary>
public class ChatHub : Hub<IChatClient>
{
    /// <summary>
    /// Send message method
    /// </summary>
    /// <param name="chatMessageDto"><see cref="ChatMessageDto"/> instance pass to method</param>
    public async Task SendMessage(ChatMessageDto chatMessageDto)
    {
        await Clients.All.ReceiveMessage(chatMessageDto);
    }
}