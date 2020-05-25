using System;

namespace IotHub.Common.Exceptions
{
    public class ExceptionUtility
    {
        public static string GetInnerMostExceptionMessage(Exception exception)
        {
            var innerException = GetInnerMostException(exception);
            return innerException?.Message;
        }


        public static Exception GetInnerMostException(Exception exception)
        {
            while(exception?.InnerException != null)
            {
                exception = exception.InnerException;
            }
            return exception;
        }
    }
}
