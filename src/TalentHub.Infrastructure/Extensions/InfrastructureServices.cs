using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentHub.Infrastructure.Security.Models;
using TalentHub.Infrastructure.Security.OptionsSetup;

namespace TalentHub.Infrastructure.Extensions;

public static partial class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddAuth(configuration)
            .AddPersistence(configuration);
}