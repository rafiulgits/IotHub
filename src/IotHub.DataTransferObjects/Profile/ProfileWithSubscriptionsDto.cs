using IotHub.DataTransferObjects.Subscription;
using System.Collections.Generic;

namespace IotHub.DataTransferObjects.Profile
{
    public class ProfileWithSubscriptionsDto : ProfileDto
    {
       public List<SubscriptionDto> Subscriptions { get; set; }
    }
}
