using IotHub.Services.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IotHub.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperBuilder = new MapperBuilder();
            AutoMapper.IMapper mapper = mapperBuilder.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
