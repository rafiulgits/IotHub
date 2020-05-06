using IotHub.Agent.MqttClient;
using Microsoft.Extensions.Hosting;
using MQTTnet.Extensions.ManagedClient;
using System.Threading;
using System.Threading.Tasks;

namespace IotHub.Agent.Services
{
    public class MqttClientService : IHostedService
    {
        private readonly AspMqttClient aspMqttClient;

        public MqttClientService(IManagedMqttClientOptions options)
        {
            aspMqttClient = new AspMqttClient(options);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await aspMqttClient.StartClientAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await aspMqttClient.StopClientAsync();
        }
    }
}
