using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Extensions.ManagedClient;
using System.Threading.Tasks;

namespace IotHub.Agent.MqttClient
{
    public class AspMqttClient : IAspMqttClient
    {
        private readonly IManagedMqttClientOptions options;
        private readonly IManagedMqttClient mqttClient;

        public AspMqttClient(IManagedMqttClientOptions options)
        {
            this.options = options;
            mqttClient = new MqttFactory().CreateManagedMqttClient();
            mqttClient.ConnectedHandler = this;
            mqttClient.DisconnectedHandler = this;
            mqttClient.ApplicationMessageReceivedHandler = this;
        }

        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            System.Console.WriteLine($"{eventArgs.ApplicationMessage.Topic}");
        }

        public async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            System.Console.WriteLine("connected");
            await mqttClient.SubscribeAsync("#");
        }

        public async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            System.Console.WriteLine($"disconnected: {eventArgs.ClientWasConnected}");
            System.Console.WriteLine(eventArgs.Exception.Message);
        }

        public async Task StartClientAsync()
        {
            await mqttClient.StartAsync(options);
        }

        public async Task StopClientAsync()
        {
            await mqttClient.StopAsync();
        }
    }
}
