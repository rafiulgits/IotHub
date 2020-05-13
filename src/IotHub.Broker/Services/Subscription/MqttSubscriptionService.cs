using IotHub.Services.Profile;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Subscription
{
    public class MqttSubscriptionService : IMqttSubscriptionService, IMqttConfigurationService
    {
        private readonly IProfileService profileService;
        private IMqttServer mqttServer;

        public MqttSubscriptionService(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        public void ConfigureMqttServer(IMqttServer mqttServer)
        {
            this.mqttServer = mqttServer;
            mqttServer.ClientSubscribedTopicHandler = this;
            mqttServer.ClientUnsubscribedTopicHandler = this;
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            options.WithSubscriptionInterceptor(this);
            options.WithUnsubscriptionInterceptor(this);
        }

        public Task HandleClientSubscribedTopicAsync(MqttServerClientSubscribedTopicEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleClientUnsubscribedTopicAsync(MqttServerClientUnsubscribedTopicEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public async Task InterceptSubscriptionAsync(MqttSubscriptionInterceptorContext context)
        {
            if(context.TopicFilter.Topic.StartsWith("$SYS", System.StringComparison.OrdinalIgnoreCase))
            {
                context.AcceptSubscription = false;
                return;
            }
            var hasSubscription = await profileService.HasSubscription(context.ClientId, context.TopicFilter.Topic);
            if(hasSubscription)
            {
                context.AcceptSubscription = true;
            }
            else
            {
                context.AcceptSubscription = false;
            }
        }

        public Task InterceptUnsubscriptionAsync(MqttUnsubscriptionInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
