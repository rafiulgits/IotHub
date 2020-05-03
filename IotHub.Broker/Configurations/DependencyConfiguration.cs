using IotHub.Repositories.User;
using IotHub.Services.Authentication;
using IotHub.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.Broker.Configurations
{
    public static class DependencyConfiguration
    {
        public static void AddServicesAndRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}
