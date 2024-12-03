using System;

namespace TrueChat.Core.Models;

public class ChatMessage
{
    public Ulid Id { get; set; }

    public DateTimeOffset SendAt { get; set; }

    public string? Text { get; set; }

    public string? Nickname { get; set; }
}