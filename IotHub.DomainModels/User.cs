using IotHub.Common.Enums;
using IotHub.DomainModels.Base;
using System;
using System.Collections.Generic;

namespace IotHub.DomainModels
{
    public class User : BaseEntityWithLog
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsConnected { get; set; } = false;
        public DateTime LastConnected { get; set; } = DateTime.MinValue;
        public List<DateTime> Logs { get; set; }
    }
}
