using System.ComponentModel.DataAnnotations;

namespace IotHub.DataTransferObjects.Subscription
{
    public class SubscriptionUpsertDto
    {
        [Required]
        public string ProfileId { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
