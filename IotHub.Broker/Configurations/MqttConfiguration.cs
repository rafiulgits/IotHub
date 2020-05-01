using IotHub.Broker.Services.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.AspNetCore;

namespace IotHub.Broker.Configurations
{
    public static class MqttConfiguration
    {
        public static void ConfigureMqttService(this IServiceCollection services)
        {
            services.AddSingleton<MqttServerService>();
            services.AddHostedMqttServerWithServices(options =>
            {
                var mqttService = options.ServiceProvider.GetRequiredService<MqttServerService>();
                mqttService.ConfigureMqttServerOptions(options);
            });
            services.AddMqttConnectionHandler();
            services.AddMqttWebSocketServerAdapter();
        }

        public static void UseConfiguredMqttServer(this IApplicationBuilder app)
        {
            app.UseMqttEndpoint("/mqtt");
            app.UseMqttServer(mqttServer =>
            {
                app.ApplicationServices.GetRequiredService<MqttServerService>()
                                       .ConfigureMqttServer(mqttServer);
            });
        }
    }
}
