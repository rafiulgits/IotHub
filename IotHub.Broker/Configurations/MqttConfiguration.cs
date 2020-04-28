using IotHub.Broker.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.AspNetCore;

namespace IotHub.Broker.Configurations
{
    public static class MqttConfiguration
    {
        public static void ConfigureMqttService(this IServiceCollection services)
        {
            services.AddSingleton<MqttService>();
            services.AddHostedMqttServerWithServices(options =>
            {
                var mqttService = options.ServiceProvider.GetRequiredService<MqttService>();
                mqttService.ConfigureMqttServerOptions(options);
            });
            services.AddMqttConnectionHandler();
            services.AddMqttWebSocketServerAdapter();
        }

        public static void UseConfiguredMqttServer(this IApplicationBuilder app)
        {
            app.UseMqttEndpoint();
            app.UseMqttServer(mqttServer =>
            {
                app.ApplicationServices.GetRequiredService<MqttService>().ConfigureMqttServer(mqttServer);
            });
        }
    }
}
