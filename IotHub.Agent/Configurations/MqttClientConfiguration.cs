using IotHub.Agent.Options;
using IotHub.Agent.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System;

namespace IotHub.Agent.Configurations
{
    public static class MqttClientConfiguration
    {
        public static void AddHostedMqttClient(this IServiceCollection services)
        {
            services.AddConfiguredMqttClientService(optionBuilder =>
            {
                optionBuilder
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(new MqttClientOptionsBuilder()
                    .WithClientId("5eb41b93e48d4d2d10151f16")
                    .WithCredentials("agent", "12345678")
                    .WithTcpServer("localhost", 1883)
                    .Build());
            });
        }

        private static IServiceCollection AddConfiguredMqttClientService(this IServiceCollection services,
                    Action<AspCoreManagedMqttClientOptionBuilder> configuration)
        {
            services.AddSingleton<IManagedMqttClientOptions>(serviceProvider =>
            {
                var optionsBuilder = new AspCoreManagedMqttClientOptionBuilder(serviceProvider);
                configuration(optionsBuilder);
                return optionsBuilder.Build();
            });
            services.AddSingleton<MqttClientService>();
            services.AddSingleton<IHostedService>(serviceProvider =>
            {
                return serviceProvider.GetService<MqttClientService>();
            });
            return services;
        }
    }
}
