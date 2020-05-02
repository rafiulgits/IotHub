using IotHub.Services.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfiguration = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            AutoMapper.IMapper mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
