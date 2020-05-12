using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Publishing
{
    public interface IMqttPublishingService : IMqttServerApplicationMessageInterceptor, 
                                              IMqttServerClientMessageQueueInterceptor,
                                              IMqttConfigurationService
    {
        Task ExecuteSystemCommandAsync(MqttApplicationMessageInterceptorContext context);
    }
}
