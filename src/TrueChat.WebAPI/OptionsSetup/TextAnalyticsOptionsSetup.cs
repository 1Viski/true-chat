using Microsoft.Extensions.Options;
using TrueChat.Core.Options;

namespace TrueChat.WebAPI.OptionsSetup;

public class TextAnalyticsOptionsSetup : IConfigureOptions<TextAnalyticsOptions>
{
    private const string SectionName = "Azure:TextAnalytics";
    private readonly IConfiguration _configuration;

    public TextAnalyticsOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(TextAnalyticsOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}