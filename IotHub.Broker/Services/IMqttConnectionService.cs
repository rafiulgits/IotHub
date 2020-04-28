using MQTTnet.Server;

namespace IotHub.Broker.Services
{
    public interface IMqttConnectionService : IMqttServerConnectionValidator, IMqttServerClientConnectedHandler, IMqttServerClientDisconnectedHandler
    {
    }
}
