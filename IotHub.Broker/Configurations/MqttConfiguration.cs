using Microsoft.Extensions.DependencyInjection;
using MQTTnet.AspNetCore;

namespace IotHub.Broker.Configurations
{
    public static class MqttConfiguration
    {
        public static void ConfigureMqttService(this IServiceCollection services)
        {
            services.AddSingleton<BrokerManager>();
            services.AddHostedMqttServerWithServices(configure =>
            {
                var brokerManager = configure.ServiceProvider.GetRequiredService<BrokerManager>();
                configure
                .WithDefaultEndpointPort(1883)
                .WithConnectionValidator(brokerManager.ConnectionValidationHandler)
                .WithSubscriptionInterceptor(brokerManager.SubscriptionHandler)
                .WithApplicationMessageInterceptor(brokerManager.IncomingMessageHandler);
            });
            services.AddMqttConnectionHandler();
            services.AddMqttWebSocketServerAdapter();
        }
    }
}
