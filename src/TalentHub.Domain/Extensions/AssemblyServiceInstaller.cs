using Microsoft.Extensions.DependencyInjection;
using TalentHub.Domain.Core.Abstractions;

namespace TalentHub.Domain.Extensions;

public static class AssemblyServiceInstaller
{
    public static IServiceCollection AddDefinedServices(this IServiceCollection services)
    {
        AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(a =>
                a.GetTypes()
                    .Where(t =>
                        t.GetInterfaces().Any(i => i == typeof(IService)))).ToList()
            .ForEach(
                implementationType =>
                {
                    var serviceType = implementationType.GetInterfaces().First(i => i != typeof(IService));
                    var abstractionType = implementationType.GetInterfaces().First(i => i == typeof(IService));

                    if (serviceType == typeof(ITransientService))
                    {
                        services.AddTransient(abstractionType, implementationType);
                    }
                    else if (serviceType == typeof(IScopedService))
                    {
                        services.AddScoped(abstractionType, implementationType);
                    }
                    else if (serviceType == typeof(ISingletonService))
                    {
                        services.AddSingleton(abstractionType, implementationType);
                    }
                });

        return services;
    }
}