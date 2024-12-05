using TrueChat.Core.Dtos;

namespace TrueChat.Core.Interfaces;

public interface IChatClient
{
    public Task ReceiveMessage(ChatMessageDto chatMessageDto);
}