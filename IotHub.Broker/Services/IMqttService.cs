using MQTTnet.AspNetCore;
using MQTTnet.Server;

namespace IotHub.Broker.Services
{
    public interface IMqttService
    {
        void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options);
        void ConfigureMqttServer(IMqttServer mqtt);
    }
}
