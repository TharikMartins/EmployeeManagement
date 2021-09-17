using Management.API.Response;
using Management.Domain.Interfaces;
using Management.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Management.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogRepository logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await this.HandlerErrorAsync(context, ex, logger);
            }
        }

        private async Task HandlerErrorAsync(HttpContext context, Exception ex, ILogRepository logger)
        {
            var contextRq = context.Request;
            Task loggerResut = logger.LogAsync(new Log(contextRq.Method, contextRq.Path.Value, $"{ex.Message} , {ex.StackTrace}"));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse(string.Empty, $"{ex.Message} , {ex.StackTrace}")));
            await loggerResut;
        }
    }
}
