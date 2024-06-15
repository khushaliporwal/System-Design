using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace aspnetcoreapp
{
    public class RequestPortMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestPortMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Capture the port number from the request
            var port = context.Connection.LocalPort.ToString();
            context.Items["ServerPort"] = port;

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

    // Extension method to add the middleware to the pipeline
    public static class RequestPortMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestPortMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestPortMiddleware>();
        }
    }
}