using System.Resources;
using Microsoft.AspNetCore.Builder;

namespace ProductManagementRestAPI.ExceptionHandling
{
    public static class ConfigExceptionHandler
    {
        public static void ConfigGravityExceptionMiddleware(this IApplicationBuilder app, ResourceManager resource)
        {
            ExceptionMiddleware.ResourceManager = resource;
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}