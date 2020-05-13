using IotHub.Broker.Services.Internal;
using IotHub.Common.Values;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System.Linq;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Publishing
{
    public class MqttPublishingService : IMqttPublishingService
    {
        private IMqttServer mqttServer;
        private IMqttInternalService internalService;
        private readonly BrokerCommandTopics brokerCommandTopics;
        private readonly BrokerEventTopics brokerEventTopics;

        public MqttPublishingService(BrokerCommandTopics brokerCommandTopics, BrokerEventTopics brokerEventTopics)
        {
            this.brokerCommandTopics = brokerCommandTopics;
            this.brokerEventTopics = brokerEventTopics;
        }

        public void ConfigureMqttServer(IMqttServer mqttServer)
        {
            this.mqttServer = mqttServer;
            this.internalService = new MqttInternalService(mqttServer, brokerCommandTopics, brokerEventTopics);
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            options.WithApplicationMessageInterceptor(this);
        }

        public async Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
        {
            if(IsSystemTopic(context.ApplicationMessage.Topic))
            {
                await internalService.ExecuteSystemCommandAsync(context);
                context.AcceptPublish = false;
                return;
            }
            context.AcceptPublish = true;
        }

        private bool IsSystemTopic(string topic)
        {
            return topic.StartsWith("$SYS");
        }

        public Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
