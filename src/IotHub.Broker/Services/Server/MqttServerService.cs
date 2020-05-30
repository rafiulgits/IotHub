using IotHub.Broker.Services.Connection;
using IotHub.Broker.Services.Publishing;
using IotHub.Broker.Services.Subscription;
using MQTTnet.AspNetCore;
using MQTTnet.Server;

namespace IotHub.Broker.Services.Server
{
    public class MqttServerService : IMqttServerService
    {
        private readonly IMqttConnectionService mqttConnectionService;
        private readonly IMqttSubscriptionService mqttSubscriptionService;
        private readonly IMqttPublishingService mqttPublishingService;

        public MqttServerService(
            IMqttConnectionService mqttConnectionService, 
            IMqttSubscriptionService mqttSubscriptionService, 
            IMqttPublishingService mqttPublishingService)
        {
            this.mqttConnectionService = mqttConnectionService;
            this.mqttSubscriptionService = mqttSubscriptionService;
            this.mqttPublishingService = mqttPublishingService;
        }

        public void ConfigureMqttServer(IMqttServer mqttServer)
        {
            mqttConnectionService.ConfigureMqttServer(mqttServer);
            mqttSubscriptionService.ConfigureMqttServer(mqttServer);
            mqttPublishingService.ConfigureMqttServer(mqttServer);
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            mqttConnectionService.ConfigureMqttServerOptions(options);
            mqttSubscriptionService.ConfigureMqttServerOptions(options);
            mqttPublishingService.ConfigureMqttServerOptions(options);
            options.WithoutDefaultEndpoint();
        }
    }
}
