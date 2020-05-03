using IotHub.DomainModels.Base;
using System;

namespace IotHub.DomainModels
{
    public class Subscription : BaseEntityWithLog
    {
        public string Path { get; set; }
        public DateTime Validity { get; set; } = DateTime.MaxValue;
    }
}
