using IotHub.Broker.Services.Connection;
using IotHub.Broker.Services.Publish;
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

        private IMqttServer mqttServer;

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
            this.mqttServer = mqttServer;
            mqttConnectionService.ConfigureMqttServer(mqttServer);
            mqttSubscriptionService.ConfigureMqttServer(mqttServer);
            mqttPublishingService.ConfigureMqttServer(mqttServer);
            MapMqttServerInterceptors();
            
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            mqttConnectionService.ConfigureMqttServerOptions(options);
            mqttSubscriptionService.ConfigureMqttServerOptions(options);
            mqttPublishingService.ConfigureMqttServerOptions(options);
            MapMqttServerOptions(options);
        }

        private void MapMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            options.WithConnectionValidator(mqttConnectionService);
            options.WithApplicationMessageInterceptor(mqttPublishingService);
            options.WithSubscriptionInterceptor(mqttSubscriptionService);
            options.WithUnsubscriptionInterceptor(mqttSubscriptionService);
        }

        private void MapMqttServerInterceptors()
        {
            mqttServer.ClientConnectedHandler = mqttConnectionService;
            mqttServer.ClientDisconnectedHandler = mqttConnectionService;
            mqttServer.ClientSubscribedTopicHandler = mqttSubscriptionService;
            mqttServer.ClientUnsubscribedTopicHandler = mqttSubscriptionService;
        }
    }
}
