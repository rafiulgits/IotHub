using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Receiving;
using System.Threading.Tasks;

namespace IotHub.Agent.MqttClient
{
    public interface IAspMqttClient : IMqttClientConnectedHandler,
                                      IMqttClientDisconnectedHandler,
                                      IMqttApplicationMessageReceivedHandler                                    
    {
        Task StartClientAsync();
        Task StopClientAsync();
    }
}
