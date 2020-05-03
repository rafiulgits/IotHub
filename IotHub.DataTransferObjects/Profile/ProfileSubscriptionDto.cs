using System.ComponentModel.DataAnnotations;

namespace IotHub.DataTransferObjects.Profile
{
    public class ProfileSubscriptionDto
    {
        [Required]
        public string ProfileId { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
