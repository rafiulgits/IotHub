using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IotHub.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                   {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id="Bearer"}
                       },
                       new string[] {}
                   }
                });
            });
        }

        public static void AddSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IotHub API v1");
            });
        }
    }
}
