using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PairingTest.API.Models.ErrorHandling;

namespace PairingTest.API.Middleware
{
    
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var errorMessage = "IMS API Error - ";
                var requestPath = httpContext.Request.Path;
                if (requestPath.HasValue)
                {
                    errorMessage += $"METHOD: {httpContext.Request.Method}, PATH: {requestPath.Value}. ";
                }
                errorMessage += $"Message: {ex.Message}";
                _logger.LogError(errorMessage, ex);
                await HandleExceptionAsync(httpContext, ex.Message, errorMessage);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string title, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails
            {
                Title = title,
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
