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

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
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
