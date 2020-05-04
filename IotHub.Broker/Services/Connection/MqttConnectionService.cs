using IotHub.Common.Enums;
using IotHub.Services.Authentication;
using IotHub.Services.User;
using MQTTnet.AspNetCore;
using MQTTnet.Server;
using System.Threading.Tasks;

namespace IotHub.Broker.Services.Connection
{
    public class MqttConnectionService : IMqttConnectionService
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;
        private IMqttServer mqttServer;

        public MqttConnectionService(IAuthenticationService authenticationService, IUserService userService)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
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

        public async Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
        {
            await userService.SetConnected(eventArgs.ClientId);
            await userService.AddLog(eventArgs.ClientId);
        }

        public async Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
        {
            await userService.SetDisconnected(eventArgs.ClientId);
        }

        public async Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            var user = await authenticationService.Authenticate(context.Username, context.Password);
            if(user == null)
            {
                context.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
            }
            else
            {
                if(user.Id != context.ClientId)
                {
                    context.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.ClientIdentifierNotValid;
                }
                else if(user.Type == UserType.Other)
                {
                    context.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.NotAuthorized;
                }
                else
                {
                    context.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.Success;
                }
            }
        }
    }
}
