using TrueChat.Core.Dtos;
using TrueChat.Core.Models;

namespace TrueChat.Core.Extensions;

/// <summary>
/// Extensions <see cref="ChatMessage"/> mapping
/// </summary>
public static class ChatExtensions
{
    /// <summary>
    /// Map to <see cref="ChatMessage"/> response
    /// </summary>
    /// <param name="chatMessage">Instance of <see cref="ChatMessage"/></param>
    /// <returns><see cref="ChatMessageDto"/> response</returns>
    public static ChatMessageDto MapToChatMessageDto(this ChatMessage chatMessage)
    {
        return new ChatMessageDto(
            chatMessage.Text,
            chatMessage.Nickname,
            chatMessage.SendAt,
            chatMessage.Sentiment);
    }
    
    /// <summary>
    /// Map to <see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/> response
    /// </summary>
    /// <param name="chatMessages">Instance of <see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/></param>
    /// <returns><see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/> response</returns>
    public static IEnumerable<ChatMessageDto> MapToChatMessageDto(this IEnumerable<ChatMessage> chatMessages)
    {
        return chatMessages.Select(x => x.MapToChatMessageDto());
    }

    /// <summary>
    /// Reverse map to <see cref="ChatMessage"/> response
    /// </summary>
    /// <param name="chatMessageDto">Instance of <see cref="ChatMessage"/> response</param>
    /// <returns><see cref="ChatMessage"/></returns>
    public static ChatMessage MapToChatMessage(this ChatMessageDto chatMessageDto)
    {
        return new ChatMessage
        {
            Id = default,
            SendAt = chatMessageDto.SendAt,
            Text = chatMessageDto.Text,
            Nickname = chatMessageDto.Nickname,
            Sentiment = chatMessageDto.Sentiment
        };
    }

    /// <summary>
    /// Reverse map to <see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/> response
    /// </summary>
    /// <param name="chatMessageDtos">Instance <see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/> response</param>
    /// <returns><see cref="IEnumerable{T}"/>, T: <see cref="ChatMessage"/></returns>
    public static IEnumerable<ChatMessage> MapToChatMessage(this IEnumerable<ChatMessageDto> chatMessageDtos)
    {
        return chatMessageDtos.Select(x => x.MapToChatMessage());
    }
}