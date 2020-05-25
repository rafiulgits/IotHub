using IotHub.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace IotHub.API.Configuration
{
    public static class ExceptionHandlerConfiguration
    {
        public static void UseIotHubExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(option =>
            {
                option.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = feature?.Error;
                    var exceptionData = ExceptionResponseUtility.GetStatusCodeFromException(exception);
                    //TODO: make a model
                    var problemDetails = new
                    {
                        Status = exceptionData.StatusCodeValue,
                        Message = exceptionData.Message,
                        Instance = feature?.Path
                    };

                    var serializedExceptionResponse = string.Empty;
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.StatusCode = exceptionData.StatusCodeValue;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(serializedExceptionResponse).ConfigureAwait(false);
                });
            });
        }
    }
}
