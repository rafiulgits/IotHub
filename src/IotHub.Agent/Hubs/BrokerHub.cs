using IotHub.Agent.Services;
using IotHub.Common.Values;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IotHub.Agent.Hubs
{
    [Authorize]
    public class BrokerHub : Hub<IBrokerEvent>
    {
        private readonly IMqttClientService mqttClientService;
        private readonly BrokerCommandTopics CommandTopics;
        public BrokerHub(MqttClientServiceProvider provider, BrokerCommandTopics commandTopics)
        {
            mqttClientService = provider.MqttClientService;
            CommandTopics = commandTopics;
        }

        public async Task RequestMqttBroker(string topic, string payload)
        {
            await mqttClientService.PublishAsync(topic, payload);
        }
    }
}
