using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Internal
{
    public interface IMqttInternalService
    {
        Task ServeConnectedClientsAsync();
        Task ServeConnectedClientsCountAsync();
        Task ServeDisconnectedClientsAsync();
        Task ServeDisconnectedClientsCountAsync();
        Task ServeClientIPAsync(string clientId);
        Task ServeClientConnectedTimeAsync(string clientId);
        Task ExecuteSystemCommandAsync(MqttApplicationMessageInterceptorContext context);
    }
}
