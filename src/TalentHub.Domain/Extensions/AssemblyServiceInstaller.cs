using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TalentHub.Domain.Core.Abstractions;

namespace TalentHub.Domain.Extensions;

public static class AssemblyServiceInstaller
{
    public static IServiceCollection AddDefinedServices(this IServiceCollection services)
    {
        services.TryAddEnumerable(
            GetServicesImplementationsTypes()
                .SelectMany(serviceImplementationType =>
                    GetServiceAbstractTypes(serviceImplementationType).Select(serviceAbstractionType => new ServiceDescriptor(
                        serviceAbstractionType,
                        serviceImplementationType,
                        GetServiceLifetime(serviceImplementationType))))
        );

        return services;
    }

    private static IEnumerable<Type> GetServiceAbstractTypes(Type serviceImplementationType) =>
        serviceImplementationType.GetInterfaces().Where(p => !p.IsAssignableTo(typeof(IService)));

    private static ServiceLifetime GetServiceLifetime(Type serviceImplementationType) =>
        serviceImplementationType switch
        {
            _ when serviceImplementationType.IsAssignableTo(typeof(IScopedService)) => ServiceLifetime.Scoped,
            _ when serviceImplementationType.IsAssignableTo(typeof(ISingletonService)) => ServiceLifetime.Singleton,
            _ when serviceImplementationType.IsAssignableTo(typeof(ITransientService)) => ServiceLifetime.Transient,
            _ => ServiceLifetime.Transient
        };

    private static IEnumerable<Type> GetServicesImplementationsTypes() =>
        GetAllAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetInterfaces().Any(i => i.IsAssignableTo(typeof(IService))));

    private static IEnumerable<Assembly> GetAllAssemblies() =>
        AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(a => a.FullName != null && a.FullName.Contains("TalentHub"));
}