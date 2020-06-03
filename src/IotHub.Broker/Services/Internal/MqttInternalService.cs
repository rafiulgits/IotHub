using IotHub.Common.Values;
using MQTTnet;
using MQTTnet.Server;
using MQTTnet.Server.Status;
using System.Linq;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Internal
{
    public class MqttInternalService : IMqttInternalService
    {
        private readonly IMqttServer mqttServer;
        private readonly BrokerCommandTopics commandTopics;
        private readonly BrokerEventTopics eventTopics;

        public MqttInternalService(IMqttServer mqttServer, BrokerCommandTopics commandTopics, BrokerEventTopics eventTopics)
        {
            this.mqttServer = mqttServer;
            this.commandTopics = commandTopics;
            this.eventTopics = eventTopics;
        }


        private string GetClientIdFromPayload(MqttApplicationMessage message)
        {
            var payload = System.Text.Encoding.UTF8.GetString(message.Payload);
            // TODO: for JSON type data transfer get clientId from json payload
            return payload;
        }

        private async Task<IMqttClientStatus> GetClientStatusAsync(string clientId)
        {
            var allClientsStatus = await mqttServer.GetClientStatusAsync();
            return allClientsStatus.Where(cs => cs.ClientId == clientId).FirstOrDefault();
        }

        public async Task DisconnectClientAsync(string clientId)
        {
            var clientStatus = await GetClientStatusAsync(clientId);
            if (clientStatus != null)
            {
                await clientStatus.DisconnectAsync();
            }
        }

        public async Task ExecuteSystemCommandAsync(MqttApplicationMessageInterceptorContext context)
        {
            if (context.ApplicationMessage.Topic == commandTopics.GetConnectedClients)
            {
                await ServeConnectedClientsAsync();
            }
            else if (context.ApplicationMessage.Topic == commandTopics.GetDisconnectedClients)
            {
                await ServeDisconnectedClientsAsync();
            }
            else if (context.ApplicationMessage.Topic == commandTopics.GetConnectedClientsCount)
            {
                await ServeConnectedClientsCountAsync();
            }
            else if (context.ApplicationMessage.Topic == commandTopics.GetDisconnectedClientsCount)
            {
                await ServeDisconnectedClientsCountAsync();
            }
            else if (context.ApplicationMessage.Topic == commandTopics.PatchDisconnectClient)
            {
                string clientId = GetClientIdFromPayload(context.ApplicationMessage);
                await DisconnectClientAsync(clientId);
            }
            else if (context.ApplicationMessage.Topic == commandTopics.GetClientIP)
            {
                string clientId = GetClientIdFromPayload(context.ApplicationMessage);
                await ServeClientIPAsync(clientId);
            }
            else if (context.ApplicationMessage.Topic == commandTopics.GetClientConnectedTime)
            {
                string clientId = GetClientIdFromPayload(context.ApplicationMessage);
                await ServeClientConnectedTimeAsync(clientId);
            }
        }

        public Task ServeClientConnectedTimeAsync(string clientId)
        {
            throw new System.NotImplementedException();
        }

        public async Task ServeClientIPAsync(string clientId)
        {
            var clientStatus = await GetClientStatusAsync(clientId);
            var serializedData = Utf8Json.JsonSerializer.Serialize(new { IP = clientStatus.Endpoint });
            var message = new MqttApplicationMessageBuilder().WithTopic(eventTopics.ClientIP(clientId))
                                                             .WithPayload(serializedData)
                                                             .Build();
            await mqttServer.PublishAsync(message);
        }

        public async Task ServeConnectedClientsAsync()
        {
            var clientsStatus = await mqttServer.GetClientStatusAsync();
            var connectedClientsId = clientsStatus.Select(cs => cs.ClientId);
            var serializedClientsId = Utf8Json.JsonSerializer.Serialize(new { IDList = connectedClientsId });
            var message = new MqttApplicationMessageBuilder().WithTopic(eventTopics.ConnectedClients)
                                                             .WithPayload(serializedClientsId)
                                                             .Build();
            await mqttServer.PublishAsync(message);
        }

        public async Task ServeConnectedClientsCountAsync()
        {
            var clientsStatus = await mqttServer.GetClientStatusAsync();
            var serializedClientsCount = Utf8Json.JsonSerializer.Serialize(new { Counts = clientsStatus.Count });
            var message = new MqttApplicationMessageBuilder().WithTopic(eventTopics.ConnectedClientsCount)
                                                             .WithPayload(serializedClientsCount)
                                                             .Build();
            await mqttServer.PublishAsync(message);
        }

        public Task ServeDisconnectedClientsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task ServeDisconnectedClientsCountAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
