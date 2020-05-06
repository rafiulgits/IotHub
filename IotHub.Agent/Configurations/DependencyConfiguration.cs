using IotHub.DB.Mongo;
using IotHub.Repositories.Profile;
using IotHub.Repositories.User;
using IotHub.Services.Profile;
using IotHub.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.Agent.Configurations
{
    public static class DependencyConfiguration
    {
        public static void AddRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbSettings>();
            services.AddSingleton<MongoDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
