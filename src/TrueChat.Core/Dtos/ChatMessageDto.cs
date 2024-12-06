using TrueChat.Core.Enums;

namespace TrueChat.Core.Dtos;

public record ChatMessageDto(
    string? Text, 
    string? Nickname, 
    DateTimeOffset SendAt, 
    SentimentLabel Sentiment);