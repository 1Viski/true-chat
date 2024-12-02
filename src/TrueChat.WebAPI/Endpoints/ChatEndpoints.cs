using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Models;
using TrueChat.Core.Services;

namespace TrueChat.WebAPI.Endpoints;

public static class ChatEndpoints
{
    public static void MapChatEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/chat-messages", GetMessages);
        app.MapPost("/api/v1/chat-messages", AddMessage);
    }

    private static async Task<Results<Ok<IEnumerable<ChatMessage>>, NotFound>> 
        GetMessages(IChatService chatService, CancellationToken cancellationToken)
    {
        var messages = await chatService.GetMessagesAsync(cancellationToken);
        return TypedResults.Ok(messages);
    }

    private static async Task<Results<Ok<ChatMessage>, ProblemHttpResult>> 
        AddMessage([FromBody] ChatMessage message, IChatService chatService, CancellationToken cancellationToken)
    {
        await chatService.AddMessageAsync(message, cancellationToken);
        return TypedResults.Ok(message);
    }
}