using IotHub.DataTransferObjects.Base;
using System;
using System.Collections.Generic;

namespace IotHub.DataTransferObjects.User
{
    public class UserLogsDto : BaseDto
    {
        public List<DateTime> Logs { get; set; }
    }
}
