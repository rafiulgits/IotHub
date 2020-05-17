using IotHub.Common.Enums;
using IotHub.Common.Extensions;
using IotHub.Common.Values;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.API.Configuration
{
    public static class AuthorizationConfiguration
    {
        public static void AddIotHubAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(option => 
            {
                option.AddPolicy(PolicyName.Admin, config =>
                {
                    config.RequireRole(UserType.Admin.ToIntegerString());
                });

                option.AddPolicy(PolicyName.AdminOrAgent, config =>
                {
                    config.RequireRole(UserType.Admin.ToIntegerString(), UserType.Agent.ToIntegerString());
                });
            });
        }
    }
}
