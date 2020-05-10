using MQTTnet.Server;

namespace IotHub.Broker.Services.Subscription
{
    public interface IMqttSubscriptionService : IMqttServerClientSubscribedTopicHandler,
                                                IMqttServerSubscriptionInterceptor,
                                                IMqttServerClientUnsubscribedTopicHandler,
                                                IMqttServerUnsubscriptionInterceptor,
                                                IMqttConfigurationService
    {
    }
}
