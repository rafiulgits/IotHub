using MQTTnet.Server;

namespace IotHub.Broker.Services.Connection
{
    public interface IMqttConnectionService : IMqttServerConnectionValidator,
                                              IMqttServerClientConnectedHandler,
                                              IMqttServerClientDisconnectedHandler,
                                              IMqttConfigurationService
    {
    }
}
