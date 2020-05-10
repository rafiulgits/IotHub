namespace IotHub.Agent.Services
{
    public class MqttClientServiceProvider
    {
        public IMqttClientService MqttClientService { get; set; }

        public MqttClientServiceProvider(IMqttClientService mqttClientService)
        {
            MqttClientService = mqttClientService;
        }
    }
}
