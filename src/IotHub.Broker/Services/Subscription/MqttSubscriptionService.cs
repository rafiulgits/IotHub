using IotHub.Common.Exceptions;
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
            await Task.Run(() =>
            {
                context.AcceptSubscription = true;
            });
            //context.AcceptSubscription = false;
            //try
            //{
            //    var profile = await profileService.GetProfileWithSubscriptionByUserIdAsync(context.ClientId);
            //    if (context.TopicFilter.Topic.StartsWith("$SYS", System.StringComparison.OrdinalIgnoreCase) || context.TopicFilter.Topic.StartsWith("#"))
            //    {
            //        if (profile.Type == Common.Enums.ProfileType.Agent)
            //        {
            //            context.AcceptSubscription = true;
            //        }
            //    }
            //    else if (profile.Type == Common.Enums.ProfileType.Agent)
            //    {
            //        context.AcceptSubscription = true;
            //    }
            //    else
            //    {
            //        foreach (var subscription in profile.Subscriptions)
            //        {
            //            if (MqttTopicFilterComparer.IsMatch(context.TopicFilter.Topic, subscription.Path))
            //            {
            //                context.AcceptSubscription = true;
            //            }
            //        }
            //    }
            //}
            //catch(NotFoundException)
            //{
            //}
        }

        public Task InterceptUnsubscriptionAsync(MqttUnsubscriptionInterceptorContext context)
        {
            return Task.FromResult(context.AcceptUnsubscription = true);
        }
    }
}
