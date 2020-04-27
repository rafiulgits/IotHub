using MQTTnet.Server;

namespace IotHub.Broker
{
    public class BrokerManager
    {
        public virtual void ConnectionValidationHandler(MqttConnectionValidatorContext context)
        {
            
        }

        public virtual void SubscriptionHandler(MqttSubscriptionInterceptorContext context)
        {

        }

        public virtual void IncomingMessageHandler(MqttApplicationMessageInterceptorContext context)
        {

        }
    }
}
