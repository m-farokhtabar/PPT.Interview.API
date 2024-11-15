using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PPT.Interview.Application.SeedWorks.DbProvider;
using PPT.Interview.Application.SeedWorks.RestApiProvider;
using PPT.Interview.Infrastructure.DbProvider;
using PPT.Interview.Infrastructure.RestApiProvider;

namespace PPT.Interview.Infrastructure.StartupConfig;

/// <summary>
/// all Settings for using Infrastructure layer
/// </summary>
public static class InfrastructureServiceExtension
{
    /// <summary>
    /// configure services and database
    /// </summary>
    /// <param name="services"></param>
    /// <param name="dbConnection"></param>
    public static void InfrastructureConfiguration(this IServiceCollection services, string dbConnection)
    {
        services.AddScoped<IAvatarImageDbProvider, AvatarImageDbProvider>();
        services.AddScoped<IAvatarImageRestApiProvider, AvatarImageRestApiProvider>();
        services.AddDbContext<AppDbContext>(Opts => Opts.UseSqlite(dbConnection));
    }
}
