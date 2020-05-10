using IotHub.Common.Values;
using IotHub.Repositories.Profile;
using IotHub.Repositories.User;
using IotHub.Services.Authentication;
using IotHub.Services.Profile;
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

            services.AddSingleton<IProfileRepository, ProfileRepository>();
            services.AddSingleton<IProfileService, ProfileService>();

            services.AddSingleton<BrokerEventTopics>();
            services.AddSingleton<BrokerCommandTopics>();
        }
    }
}
