using Microsoft.Extensions.DependencyInjection;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Services;

namespace TrueChat.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> instance for extends method</param>
    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IAnalyticsService, AnalyticsService>();
    }
}