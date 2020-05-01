using IotHub.Services.Authentication;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Connection
{
    public class MqttConnectionService : IMqttConnectionService
    {
        private readonly IAuthenticationService authenticationService;
        private IMqttServer mqttServer;

        public MqttConnectionService(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public void ConfigureMqttServer(IMqttServer mqttServer)
        {
            this.mqttServer = mqttServer;
            mqttServer.ClientConnectedHandler = this;
            mqttServer.ClientDisconnectedHandler = this;
        }

        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            options.WithConnectionValidator(this);
        }

        public Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

        public async Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            var user = await authenticationService.Authenticate(context.Username, context.Password);
            if(user != null)
            {
                context.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.Success;
                return;
            }
            context.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
        }
    }
}
