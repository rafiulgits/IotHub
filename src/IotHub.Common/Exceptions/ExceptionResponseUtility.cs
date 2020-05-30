using System;

namespace IotHub.Common.Exceptions
{
    public class ExceptionResponseUtility
    {
        public static ExceptionData GetStatusCodeFromException(Exception exception)
        {
            var exceptionData = new ExceptionData
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = exception.Message ?? "An error occurred"
            };
            if(exception != null)
            {
                switch (exception)
                {
                    case UnauthorizedException unauthorizedException:
                        exceptionData.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                        exceptionData.Message = unauthorizedException.Message;
                        break;

                    case NotFoundException notFoundException:
                        exceptionData.StatusCode = System.Net.HttpStatusCode.NotFound;
                        exceptionData.Message = notFoundException.Message;
                        break;

                    case BadRequestException badRequestException:
                        exceptionData.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        exceptionData.Message = badRequestException.Message;
                        break;
                }
            }
            return exceptionData;
        }
    }
}
