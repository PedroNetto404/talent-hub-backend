using MinimalApi.Endpoint.Extensions;

namespace TalentHub.Presentation.Extensions;

public static class Pipeline
{
    public static WebApplication AddPipeline(this WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
            
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TalentHub API V1");
                options.DocumentTitle = "TalentHub API";
            });

            app.UseDeveloperExceptionPage();
        }
        
        app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapEndpoints();

        return app;
    }
}