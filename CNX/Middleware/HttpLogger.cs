using System;
using System.IO;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CNX.Middleware
{
    public class HttpLogger
    {

        private readonly RequestDelegate _next;

        public HttpLogger(RequestDelegate next, IHttpLoggerRepository loggerRepository)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHttpLoggerRepository loggerRepository)
        {
            var log = new HttpLogModel
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                QueryString = context.Request.QueryString.ToString(),
                IpAddress = context.Request.HttpContext.Connection.RemoteIpAddress.ToString()
            };

            if (context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();
                var body = await new StreamReader(context.Request.Body)
                    .ReadToEndAsync();
                context.Request.Body.Position = 0;
                log.Payload = body;
            }

            log.RequestedOn = DateTime.Now;
            loggerRepository.Add(log);
            await _next(context);
        }
    }
}
