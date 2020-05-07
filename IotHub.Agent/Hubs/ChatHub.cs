using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IotHub.Agent.Hubs
{
    public class ChatHub : Hub<IBrokerEvent>
    {
        public async Task OnBrokerEvent(string topic, object payload)
        {
            await Clients.Others.Broadcast(topic, payload);
        }
    }
}
