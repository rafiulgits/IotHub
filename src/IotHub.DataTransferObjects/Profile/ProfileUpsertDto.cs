using IotHub.Common.Enums;
using IotHub.DataTransferObjects.Base;
using System.ComponentModel.DataAnnotations;

namespace IotHub.DataTransferObjects.Profile
{
    public class ProfileUpsertDto : BaseDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ProfileType Type { get; set; }
    }
}
