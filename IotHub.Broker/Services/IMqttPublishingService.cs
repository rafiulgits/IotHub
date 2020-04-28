using MQTTnet.Server;

namespace IotHub.Broker.Services
{
    public interface IMqttPublishingService : IMqttServerApplicationMessageInterceptor, IMqttServerClientMessageQueueInterceptor
    {
    }
}
