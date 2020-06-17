using IotHub.Broker.Services.Internal;
using IotHub.Common.Values;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using Serilog;
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
        private readonly ILogger logger;

        public MqttPublishingService(BrokerCommandTopics brokerCommandTopics, BrokerEventTopics brokerEventTopics, ILogger logger)
        {
            this.brokerCommandTopics = brokerCommandTopics;
            this.brokerEventTopics = brokerEventTopics;
            this.logger = logger;
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
            if (IsSystemTopic(context.ApplicationMessage.Topic))
            {
                if (IsBrokerItself(context.ClientId))
                {
                    context.AcceptPublish = true;
                }
                else
                {
                    await internalService.ExecuteSystemCommandAsync(context);
                    context.AcceptPublish = false;
                    return;
                }
            }
            else
            {
                if (context.SessionItems.ContainsKey(context.ApplicationMessage.Topic))
                {
                    var retainPayload = (byte[])context.SessionItems[context.ApplicationMessage.Topic];
                    if (!retainPayload.SequenceEqual(context.ApplicationMessage.Payload))
                    {
                        var payloadString = System.Text.Encoding.UTF8.GetString(context.ApplicationMessage.Payload);
                        logger.Information(payloadString);
                    }
                }
                else
                {
                    var payloadString = System.Text.Encoding.UTF8.GetString(context.ApplicationMessage.Payload);
                    logger.Information(payloadString);
                    context.SessionItems.Add(context.ApplicationMessage.Topic, context.ApplicationMessage.Payload);
                }
                context.AcceptPublish = true;
            }
        }

        private bool IsSystemTopic(string topic)
        {
            return topic.StartsWith("$SYS");
        }

        private bool IsBrokerItself(string clientId)
        {
            return string.IsNullOrEmpty(clientId);
        }

        public Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
