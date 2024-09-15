using System;

namespace TalentHub.Web;

public static class Pipeline
{
    public static WebApplication UsePipeline(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        application.UseHttpsRedirection();

        application.UseAuthentication();
        application.UseAuthorization();

        application.UseRouting();
        application.MapControllers();

        return application;
    }
}
