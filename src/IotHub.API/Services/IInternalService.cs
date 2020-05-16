using IotHub.DataTransferObjects.User;

namespace IotHub.API.Services
{
    public interface IInternalService
    {
        public UserTokenDto InternalAuthentication(UserLoginDto loginData);
    }
}
