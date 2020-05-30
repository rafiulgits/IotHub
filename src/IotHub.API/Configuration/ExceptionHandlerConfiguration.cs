using IotHub.Common.Exceptions;
using IotHub.DataTransferObjects.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace IotHub.API.Configuration
{
    public static class ExceptionHandlerConfiguration
    {
        public static void UseIotHubExceptionHandler(this IApplicationBuilder app, bool isDev)
        {
            app.UseExceptionHandler(option =>
            {
                option.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = feature?.Error;
                    var exceptionData = ExceptionResponseUtility.GetStatusCodeFromException(exception);
                    var exceptionDetails = new ExceptionDetailsDto
                    {
                        Status = exceptionData.StatusCodeValue,
                        Message = exceptionData.Message,
                        RequestPath = feature?.Path,
                        Details = isDev ? exception?.StackTrace : null
                    };
                    var serializedExceptionResponse = string.Empty;
                    if (option.ApplicationServices.GetService(typeof(AutoMapper.IMapper)) is AutoMapper.IMapper mapper)
                    {
                        serializedExceptionResponse = exceptionDetails.ToSerializedString();
                    }
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.StatusCode = exceptionData.StatusCodeValue;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(serializedExceptionResponse).ConfigureAwait(false);
                });
            });
        }
    }
}
