using MQTTnet.Server;

namespace IotHub.Broker.Services
{
    public interface IMqttSubscriptionService : IMqttServerClientSubscribedTopicHandler, IMqttServerSubscriptionInterceptor,
        IMqttServerClientUnsubscribedTopicHandler,  IMqttServerUnsubscriptionInterceptor
    {
    }
}
