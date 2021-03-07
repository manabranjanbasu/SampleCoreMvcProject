using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairingTest.API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAppAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseAppExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
