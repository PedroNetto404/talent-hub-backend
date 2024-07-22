using Microsoft.OpenApi.Models;

namespace TalentHub.Presentation.Extensions;

public static class PresentationServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo { Title = "TalentHub API", Version = "v1" });
        });
        
        
        return services;
    }
}