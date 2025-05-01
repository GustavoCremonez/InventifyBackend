using InventifyBackend.Application.Dtos;
using InventifyBackend.Infra.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace InventifyBackend.Infra
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, bool isDevelopment, CustomerLogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        var error = ResponseDto<object>.Failure(context.Response.StatusCode, contextFeature.Error.Message, isDevelopment ? contextFeature.Error.StackTrace : "Stack trace").ToString();

                        await context.Response.WriteAsync(error);
                        logger.LogError(error);
                    }
                });
            });
        }
    }
}
