using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Subscription
{
    public class MqttSubscriptionService : IMqttSubscriptionService, IMqttConfigurationService
    {
        public void ConfigureMqttServer(IMqttServer mqtt)
        {
            throw new System.NotImplementedException();
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleClientSubscribedTopicAsync(MqttServerClientSubscribedTopicEventArgs eventArgs)
        {
            throw new System.NotImplementedException()
        }

        public Task HandleClientUnsubscribedTopicAsync(MqttServerClientUnsubscribedTopicEventArgs eventArgs)
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
    }
}
