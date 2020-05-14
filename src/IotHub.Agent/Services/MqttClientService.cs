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
        private readonly IHubContext<BrokerHub, IBrokerEvent> hubContext;

        public MqttClientService(IManagedMqttClientOptions options, IHubContext<BrokerHub, IBrokerEvent> hubContext)
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

        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            var payload = System.Text.Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload);
            System.Console.WriteLine(payload);
            await hubContext.Clients.All.Broadcast(eventArgs.ApplicationMessage.Topic, payload);
        }

        public async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            System.Console.WriteLine("Connected");
            await hubContext.Clients.All.AgentConnectionStatus(true);
        }

        public async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            System.Console.WriteLine("Disconnected: " + eventArgs.Exception.Message);
            await hubContext.Clients.All.AgentConnectionStatus(false);
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

        public async Task PublishAsync(string topic, string payload)
        {
            var applicationMessage = new MqttApplicationMessageBuilder().WithTopic(topic)
                                                                        .WithPayload(payload)
                                                                        .Build();
            var manegedApplicationMessage = new ManagedMqttApplicationMessageBuilder().WithApplicationMessage(applicationMessage)
                                                                                      .Build();
            await mqttClient.PublishAsync(manegedApplicationMessage);
        }
    }
}
