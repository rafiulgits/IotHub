using System;

namespace IotHub.Common.Exceptions
{
    public class InternalException : Exception
    {
        public InternalException(string message) : base(message)
        { }
    }
}
