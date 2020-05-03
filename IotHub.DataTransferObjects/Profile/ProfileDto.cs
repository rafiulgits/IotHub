using IotHub.Common.Enums;
using IotHub.DataTransferObjects.Base;
using IotHub.DataTransferObjects.User;

namespace IotHub.DataTransferObjects.Profile
{
    public class ProfileDto : BaseDto
    {
        public string DisplayName { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public ProfileType ProfileType { get; set; }
    }
}
