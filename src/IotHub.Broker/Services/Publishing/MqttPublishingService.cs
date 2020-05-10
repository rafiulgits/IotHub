using IotHub.Common.Values;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System.Linq;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Publishing
{
    public class MqttPublishingService : IMqttPublishingService, IMqttConfigurationService
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
            if(context.ApplicationMessage.Topic == CommandTopics.DisconnectClient)
            {
                var requestDisconectClientId = System.Text.Encoding.UTF8.GetString(context.ApplicationMessage.Payload);
                var clients = await mqttServer.GetClientStatusAsync();
                var clientStatus = clients.Where(c => c.ClientId == requestDisconectClientId).FirstOrDefault();
                if(clientStatus != null)
                {
                    await clientStatus.DisconnectAsync();
                }
                
                context.AcceptPublish = false;
                return;
            }
            context.AcceptPublish = true;
        }

        public Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
