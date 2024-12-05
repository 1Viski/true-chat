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
        app.MapGet("/api/v1/chat-messages", GetMessagesAsync);
        app.MapPost("/api/v1/chat-messages", AddMessageAsync);
        app.MapPost("/api/v1/text-sentiment", GetSentimentAsync);
    }

    /// <summary>
    /// MapGet delegate handler
    /// </summary>
    /// <param name="chatService"><see cref="IChatService"/> instance</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Minimal API  handlers</returns>
    private static async Task<Results<Ok<IEnumerable<ChatMessageDto>>, NotFound>> 
        GetMessagesAsync(IChatService chatService, CancellationToken cancellationToken)
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
        AddMessageAsync([FromBody] ChatMessageDto messageDto, IChatService chatService, CancellationToken cancellationToken)
    {
        await chatService.AddMessageAsync(messageDto.MapToChatMessage(), cancellationToken);
        return TypedResults.Ok(messageDto.MapToChatMessage());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="analyticsService"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<PlainText>, ProblemHttpResult>> 
        GetSentimentAsync([FromBody] PlainText text, IAnalyticsService analyticsService, CancellationToken cancellationToken)
    {
        var sentiment = await analyticsService.GetSentimentAsync(text.Value!, cancellationToken);
        
        var plainText = new PlainText
        {
            Value = sentiment.ToString()
        };
        
        return TypedResults.Ok(plainText);
    }
}