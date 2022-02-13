using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Exceptions.ExceptionMiddleware
{
    public class ExceptionsMiddleware
    {
        private readonly IHostEnvironment env;
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionsMiddleware> logger;

        public ExceptionsMiddleware(IHostEnvironment env, RequestDelegate requestDelegate, ILogger<ExceptionsMiddleware> logger)
        {
            this.env = env;
            this.requestDelegate = requestDelegate;
            this.logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

                var response = env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal server error.");

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
