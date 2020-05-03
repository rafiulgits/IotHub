using System;

namespace IotHub.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { 
        }
    }
}
