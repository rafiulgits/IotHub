using IotHub.Common.Enums;
using IotHub.DataTransferObjects.Base;
using System;

namespace IotHub.DataTransferObjects.User
{
    public class UserDto :BaseDtoWithLog
    {
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public bool IsConnected { get; set; }
        public DateTime LastConnected { get; set; }
    }
}
