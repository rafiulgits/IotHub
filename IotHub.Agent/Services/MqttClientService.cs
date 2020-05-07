using IotHub.Agent.Hubs;
using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Extensions.ManagedClient;
using System.Threading;
using System.Threading.Tasks;

namespace IotHub.Agent.Services
{
    public class MqttClientService : IMqttClientService
    {
        private readonly IManagedMqttClient mqttClient;
        private readonly IManagedMqttClientOptions options;
        private readonly IHubContext<ChatHub, IBrokerEvent> hubContext;

        public MqttClientService(IManagedMqttClientOptions options, IHubContext<ChatHub, IBrokerEvent> hubContext)
        {
            this.hubContext = hubContext;
            this.options = options;
            mqttClient = new MqttFactory().CreateManagedMqttClient();
            ConfigureMqttClient();
        }

        private void ConfigureMqttClient()
        {
            mqttClient.ConnectedHandler = this;
            mqttClient.DisconnectedHandler = this;
            mqttClient.ApplicationMessageReceivedHandler = this;
        }

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            System.Console.WriteLine("Connected");
        }

        public async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            System.Console.WriteLine("Disconnected: " + eventArgs.Exception.Message);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await mqttClient.StartAsync(options);
            await mqttClient.SubscribeAsync("#");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await mqttClient.StopAsync();
        }
    }
}
