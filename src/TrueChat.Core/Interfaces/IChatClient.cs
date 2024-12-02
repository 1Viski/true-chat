namespace TrueChat.Core.Interfaces;

public interface IChatClient
{
    public Task ReceiveMessage(string user, string message);
}