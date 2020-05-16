using IotHub.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace IotHub.API.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            var jwtSettings = SettingsProvider.JwtSettings;
            var secretInBytes = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Secret);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => 
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secretInBytes),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        };
                        options.RequireHttpsMetadata = false;
                    });
        }
    }
}
