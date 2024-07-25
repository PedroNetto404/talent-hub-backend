namespace TalentHub.Presentation.Extensions;

public static class Pipeline
{
    public static WebApplication UsePipeline(this WebApplication app, IWebHostEnvironment env)
    {
        app
            .UseIfDevelopment(env)
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization();

        app.MapControllers();

        return app;
    }

    private static IApplicationBuilder UseIfDevelopment(this IApplicationBuilder app, IWebHostEnvironment env) =>
        env.IsDevelopment() ?
            app
                .UseSwagger(options =>
                {
                    options.RouteTemplate = "swagger/{documentName}/swagger.json";
                })
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "TalentHub API V1");
                    options.DocumentTitle = "TalentHub API";
                })
                .UseDeveloperExceptionPage() :
            app;
}