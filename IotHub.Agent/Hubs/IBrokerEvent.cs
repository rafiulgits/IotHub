using System.Threading.Tasks;

namespace IotHub.Agent.Hubs
{
    public interface IBrokerEvent
    {
        Task Broadcast(string topic, object payload);
    }
}
