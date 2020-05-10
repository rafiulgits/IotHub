using System;

namespace IotHub.DataTransferObjects.Base
{
    public class BaseDtoWithLog : BaseDto
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
