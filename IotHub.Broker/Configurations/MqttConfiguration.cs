using IotHub.Broker.Services.Connection;
using IotHub.Broker.Services.Publishing;
using IotHub.Broker.Services.Server;
using IotHub.Broker.Services.Subscription;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.AspNetCore;

namespace IotHub.Broker.Configurations
{
    public static class MqttConfiguration
    {
        public static void ConfigureMqttService(this IServiceCollection services)
        {
            services.AddSingleton<IMqttConnectionService, MqttConnectionService>();
            services.AddSingleton<IMqttSubscriptionService, MqttSubscriptionService>();
            services.AddSingleton<IMqttPublishingService, MqttPublishingService>();
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
                app.ApplicationServices.GetRequiredService<MqttServerService>().ConfigureMqttServer(mqttServer);
            });
        }
    }
}
