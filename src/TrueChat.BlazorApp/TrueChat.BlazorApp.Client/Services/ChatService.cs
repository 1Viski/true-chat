using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TrueChat.BlazorApp.Client.Clients;
using TrueChat.BlazorApp.Client.Models;

namespace TrueChat.BlazorApp.Client.Services;

public class ChatService : IChatService
{
    private readonly IChatClient _chatClient;

    public ChatService(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<IEnumerable<ChatMessage>> GetMessagesAsync()
    {
        return await _chatClient.GetMessagesAsync();
    }

    public async Task<ChatMessage> AddMessageAsync(ChatMessage message)
    {
        return await _chatClient.AddMessageAsync(message);
    }
}