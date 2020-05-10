using IotHub.Agent.Services;
using IotHub.Common.Values;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IotHub.Agent.Hubs
{
    public class BrokerHub : Hub<IBrokerEvent>
    {
        private readonly IMqttClientService mqttClientService;
        private readonly BrokerCommandTopics CommandTopics;
        public BrokerHub(MqttClientServiceProvider provider, BrokerCommandTopics commandTopics)
        {
            mqttClientService = provider.MqttClientService;
            CommandTopics = commandTopics;
        }

        public async Task MqttClientDisconnectCommand(string clientId)
        {
            await mqttClientService.PublishAsync(CommandTopics.DisconnectClient, clientId);
        }
    }
}
