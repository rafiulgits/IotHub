using IotHub.Common.Enums;
using IotHub.DomainModels.Base;
using System.Collections.Generic;

namespace IotHub.DomainModels
{
    public class Profile : BaseEntityWithLog
    {
        public string DisplayName { get; set; }
        public string UserId { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public ProfileType Type { get; set; }
    }
}
