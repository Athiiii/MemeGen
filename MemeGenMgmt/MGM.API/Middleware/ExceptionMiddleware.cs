using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MGM.API.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void AddExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            //register
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //get Status code
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        //log Message
                        logger.LogError($"An error appeared: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
