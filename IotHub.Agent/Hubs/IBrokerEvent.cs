using System.Threading.Tasks;

namespace IotHub.Agent.Hubs
{
    public interface IBrokerEvent
    {
        Task Broadcast(string topic, string payload);
        Task AgentConnectionStatus(bool isConnected);
    }
}
