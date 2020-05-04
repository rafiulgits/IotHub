using IotHub.Common.Enums;
using IotHub.DataTransferObjects.Base;

namespace IotHub.DataTransferObjects.Profile
{
    public class ProfileDto : BaseDtoWithLog
    {
        public string DisplayName { get; set; }
        public string UserId { get; set; }
        public ProfileType Type { get; set; }
    }
}
