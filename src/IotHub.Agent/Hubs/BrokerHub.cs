using IotHub.Agent.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IotHub.Agent.Hubs
{
    public class BrokerHub : Hub<IBrokerEvent>
    {
        private readonly IMqttClientService mqttClientService;
        public BrokerHub(MqttClientServiceProvider provider)
        {
            mqttClientService = provider.MqttClientService;
        }

        public async Task MqttClientDisconnectCommand(string clientId)
        {
            await mqttClientService.PublishAsync("$SYS/users/disconnected/command", clientId);
        }
    }
}
