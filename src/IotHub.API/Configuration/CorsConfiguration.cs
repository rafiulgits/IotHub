using IotHub.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.API.Configuration
{
    public static class CorsConfiguration
    {
        public static void AddConfiuredCors(this IServiceCollection services)
        {
            var corsSettings = SettingsProvider.CorsSettings;
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .WithOrigins(corsSettings.AllowedHosts)
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
