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
        private readonly BrokerCommandTopics CommandTopics;

        public MqttPublishingService(BrokerCommandTopics brokerCommandTopics)
        {
            CommandTopics = brokerCommandTopics;
        }

        public void ConfigureMqttServer(IMqttServer mqttServer)
        {
            this.mqttServer = mqttServer;
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            options.WithApplicationMessageInterceptor(this);
        }

        public async Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
        {
            if(IsSystemTopic(context.ApplicationMessage.Topic))
            {
                await ExecuteSystemCommandAsync(context);
                return;
            }
            context.AcceptPublish = true;
        }


        private bool IsSystemTopic(string topic)
        {
            return topic.IndexOf("$SYS") == 0;
        }

        public Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }

        public async Task ExecuteSystemCommandAsync(MqttApplicationMessageInterceptorContext context)
        {
            // TODO: make another service to handle commands and execute associated task
            if(context.ApplicationMessage.Topic == CommandTopics.DisconnectClient)
            {
                var requestDisconectClientId = System.Text.Encoding.UTF8.GetString(context.ApplicationMessage.Payload);
                var clients = await mqttServer.GetClientStatusAsync();
                var clientStatus = clients.Where(c => c.ClientId == requestDisconectClientId).FirstOrDefault();
                if (clientStatus != null)
                {
                    await clientStatus.DisconnectAsync();
                }
            }
            context.AcceptPublish = false;
        }
    }
}
