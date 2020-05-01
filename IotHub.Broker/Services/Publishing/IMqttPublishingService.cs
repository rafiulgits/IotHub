using MQTTnet.Server;

namespace IotHub.Broker.Services.Publishing
{
    public interface IMqttPublishingService : IMqttServerApplicationMessageInterceptor, 
                                              IMqttServerClientMessageQueueInterceptor,
                                              IMqttConfigurationService
    {
    }
}
