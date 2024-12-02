using Microsoft.AspNetCore.SignalR;
using TrueChat.Core.Interfaces;

namespace TrueChat.WebAPI.Hubs;

public class ChatHub : Hub<IChatClient>
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.ReceiveMessage(user, message);
    }
}