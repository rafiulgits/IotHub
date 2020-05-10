using IotHub.Repositories.Profile;
using IotHub.Repositories.User;
using IotHub.Services.Authentication;
using IotHub.Services.Profile;
using IotHub.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.API.Configuration
{
    public static class DependencyConfiguration
    {
        public static void AddServicesAndRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
