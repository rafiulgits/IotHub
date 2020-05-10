using IotHub.DataTransferObjects.Base;
using System;

namespace IotHub.DataTransferObjects.Subscription
{
    public class SubscriptionDto : BaseDtoWithLog
    {
        public string Path { get; set; }
        public DateTime Validity { get; set; }
    }
}
