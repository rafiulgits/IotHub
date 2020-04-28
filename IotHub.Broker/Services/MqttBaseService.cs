using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services
{
    public class MqttBaseService : IMqttConnectionService, IMqttSubscriptionService, IMqttPublishingService
    {
        public Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleClientSubscribedTopicAsync(MqttServerClientSubscribedTopicEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleClientUnsubscribedTopicAsync(MqttServerClientUnsubscribedTopicEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task InterceptSubscriptionAsync(MqttSubscriptionInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task InterceptUnsubscriptionAsync(MqttUnsubscriptionInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
