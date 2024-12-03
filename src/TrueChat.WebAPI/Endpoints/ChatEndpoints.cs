using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrueChat.Core.Dtos;
using TrueChat.Core.Extensions;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Models;

namespace TrueChat.WebAPI.Endpoints;

/// <summary>
/// Static class for Minimal API endpoints extensions
/// </summary>
public static class ChatEndpoints
{
    /// <summary>
    /// Extension method
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance this method extends.</param>
    public static void MapChatEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/chat-messages", GetMessages);
        app.MapPost("/api/v1/chat-messages", AddMessage);
    }

    /// <summary>
    /// MapGet delegate handler
    /// </summary>
    /// <param name="chatService"><see cref="IChatService"/> instance</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Minimal API  handlers</returns>
    private static async Task<Results<Ok<IEnumerable<ChatMessageDto>>, NotFound>> 
        GetMessages(IChatService chatService, CancellationToken cancellationToken)
    {
        var messages = await chatService.GetMessagesAsync(cancellationToken);
        return TypedResults.Ok(messages.MapToChatMessageDto());
    }

    /// <summary>
    /// MapPost delegate handler 
    /// </summary>
    /// <param name="messageDto"><see cref="ChatMessageDto"/> instance from body</param>
    /// <param name="chatService"><see cref="IChatService"/> instance</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Minimal API  handlers</returns>
    private static async Task<Results<Ok<ChatMessage>, ProblemHttpResult>> 
        AddMessage([FromBody] ChatMessageDto messageDto, IChatService chatService, CancellationToken cancellationToken)
    {
        await chatService.AddMessageAsync(messageDto.MapToChatMessage(), cancellationToken);
        return TypedResults.Ok(messageDto.MapToChatMessage());
    }
}