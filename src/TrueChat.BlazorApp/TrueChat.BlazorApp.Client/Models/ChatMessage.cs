using TrueChat.BlazorApp.Client.Enums;

namespace TrueChat.BlazorApp.Client.Models;

public record ChatMessage(string? Text, string? Nickname, DateTimeOffset SendAt, DocumentSentiment? Sentiment);