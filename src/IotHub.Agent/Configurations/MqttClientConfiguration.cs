using IotHub.Agent.Options;
using IotHub.Agent.Services;
using IotHub.Agent.Settings;
using IotHub.Common.Values;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System;

namespace IotHub.Agent.Configurations
{
    public static class MqttClientConfiguration
    {
        public static void AddHostedMqttClient(this IServiceCollection services, IConfiguration configuration)
        {
            var agentSettings = new AgentMqttClientSettings();
            var brokerSettings = new MqttBrokerSettings();
            configuration.GetSection(nameof(AgentMqttClientSettings)).Bind(agentSettings);
            configuration.GetSection(nameof(MqttBrokerSettings)).Bind(brokerSettings);
            services.AddConfiguredMqttClientService(optionBuilder =>
            {
                optionBuilder
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(new MqttClientOptionsBuilder()
                    .WithClientId(agentSettings.Id)
                    .WithCredentials(agentSettings.UserName, agentSettings.Password)
                    .WithTcpServer(brokerSettings.Host, brokerSettings.Port)
                    .Build());
            });

            services.AddTransient<BrokerCommandTopics>();
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
            services.AddTransient<MqttClientServiceProvider>(serviceProvider =>
            {
                var mqttClientService = serviceProvider.GetService<MqttClientService>();
                var mqttClientServiceProvider = new MqttClientServiceProvider(mqttClientService);
                return mqttClientServiceProvider;
            });
            return services;
        }
    }
}
