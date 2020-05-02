using IotHub.DB.Mongo;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.API.Configuration
{
    public static class DataContextConfiguration
    {
        public static void AddDataContext(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbSettings>();
            services.AddSingleton<MongoDbContext>();
        }
    }
}
