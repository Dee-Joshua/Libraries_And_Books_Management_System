using LABMS.Application.Common;
using LABMS.Application.Exceptions;
using LABMS.Domain.ErrorModels;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace LABMS.WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException =>StatusCodes.Status404NotFound,
                            CannotCreateException =>StatusCodes.Status406NotAcceptable,
                            _ => StatusCodes.Status500InternalServerError
                        };;
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
