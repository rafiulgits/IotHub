using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.Agent.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddConfiuredCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .WithOrigins("https://localhost:3000",
                                 "http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        public static void UseConfiguredCors(this IApplicationBuilder app)
        {
            app.UseCors();
        }
    }
}
