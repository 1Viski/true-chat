using System;

namespace TrueChat.Core.Dtos;

public record ChatMessageDto(string? Text, string? Nickname, DateTimeOffset SendAt);