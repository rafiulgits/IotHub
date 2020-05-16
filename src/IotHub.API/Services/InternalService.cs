using IotHub.API.Extentions;
using IotHub.API.Settings;
using IotHub.DataTransferObjects.User;

namespace IotHub.API.Services
{
    public class InternalService : IInternalService
    {
        public UserTokenDto InternalAuthentication(UserLoginDto loginData)
        {
            var isValid = CheckInternalCredentials(loginData);
            if(!isValid)
            {
                return null;
            }
            var user = new UserDto
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = loginData.Name,
                IsActive = true,
                IsConnected = false,
                Type = Common.Enums.UserType.Admin
            };
            var userToken = new UserTokenDto { Bearer = user.GetJwtToken() };
            return userToken;
        }

        private bool CheckInternalCredentials(UserLoginDto loginData)
        {
            var internalAuthSettings = SettingsProvider.InternalAuthSettings;
            if(!internalAuthSettings.IsActive)
            {
                return false;
            }
            return loginData.Name == internalAuthSettings.UserName &&
                   loginData.Password == internalAuthSettings.Password;
        }
    }
}
