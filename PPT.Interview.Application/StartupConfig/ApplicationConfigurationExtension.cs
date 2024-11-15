using Microsoft.Extensions.DependencyInjection;
using PPT.Interview.Application.Avatar.Queries.AvatarDetails;
using PPT.Interview.Application.Avatar.Queries.AvatarDetails.AvatarUrlStrategy;

namespace PPT.Interview.Application.StratupConfig;

/// <summary>
///  all Settings for using Application layer
/// </summary>
public static class ApplicationConfigurationExtension
{
    /// <summary>
    /// configure MediatR
    /// </summary>
    /// <param name="services"></param>
    public static void ApplicationConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AvatarQuery>());
        services.AddTransient<IAvatarUrlStrategy, Rule1AvatarUrlStrategy>();
        services.AddTransient<IAvatarUrlStrategy, Rule2AvatarUrlStrategy>();
        services.AddTransient<IAvatarUrlStrategy, Rule3AvatarUrlStrategy>();
        services.AddTransient<IAvatarUrlStrategy, Rule4AvatarUrlStrategy>();        
    }
}
