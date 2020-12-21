using ContactReport.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Project.CartAPI.ExtensionMethods
{
    public static class ExceptionExtensionMethod
    {
        public static void CustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error.Message;

                        ApiResult result = new ApiResult()
                        {
                            StatusCode = 400,
                            Success = false,
                            Message = ex
                        };

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    }
                });
            });
        }
    }
}
