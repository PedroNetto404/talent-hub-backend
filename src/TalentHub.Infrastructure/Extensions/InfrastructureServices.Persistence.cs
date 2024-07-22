using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentHub.Infrastructure.Persistence;

namespace TalentHub.Infrastructure.Extensions;

public static partial class InfrastructureServices
{
    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TalentHubDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("Default"),
                p => p.MigrationsAssembly(typeof(TalentHubDbContext).Assembly.FullName));
        });
        
        return services;
    }
}