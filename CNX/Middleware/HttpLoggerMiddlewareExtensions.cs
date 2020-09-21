using Microsoft.AspNetCore.Builder;

namespace CNX.Middleware
{
    public static class HttpLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpLogger>();
        }
    }
}
