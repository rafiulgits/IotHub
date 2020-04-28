using MQTTnet.AspNetCore;
using MQTTnet.Server;

namespace IotHub.Broker.Services
{
    public class MqttService : BaseMqttService, IMqttService
    {
        private IMqttServer mqttServer;

        public void ConfigureMqttServer(IMqttServer mqttServer)
        {
            this.mqttServer = mqttServer;
            mqttServer.ClientConnectedHandler = this;
            mqttServer.ClientDisconnectedHandler = this;
            mqttServer.ClientSubscribedTopicHandler = this;
            mqttServer.ClientUnsubscribedTopicHandler = this;
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            options.WithConnectionValidator(this);
            options.WithApplicationMessageInterceptor(this);
            options.WithSubscriptionInterceptor(this);
            options.WithUnsubscriptionInterceptor(this);
        }
    }
}
