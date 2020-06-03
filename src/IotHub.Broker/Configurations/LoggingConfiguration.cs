using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace IotHub.Broker.Configurations
{
    public static class LoggingConfiguration
    {
        public static void AddIotHubBrokerLoggingService(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration, "Serilog").CreateLogger();
            System.AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
            services.AddSingleton(Log.Logger);
        }
    }
}
