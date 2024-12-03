using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrueChat.Core.Interfaces;
using TrueChat.Core.Services;
using TrueChat.Infrastructure.Context;

namespace TrueChat.Infrastructure;

/// <summary>
/// Dependency injection extensions
/// </summary>
public static class DependencyInjection
{
    private const string ConnectionString = "AzureDb";
    
    /// <summary>
    /// Extension method
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> instance for extends method</param>
    /// <param name="configuration"><see cref="IConfiguration"/> parameter for configuration</param>
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<TrueChatDbContext>(options =>
        {
            options.UseAzureSql(configuration.GetConnectionString(ConnectionString));
        });

        services.AddSingleton<IAppDbContextFactory, AppDbContextFactory<TrueChatDbContext>>();
        services.AddScoped<IChatService, ChatService>();
    }
}