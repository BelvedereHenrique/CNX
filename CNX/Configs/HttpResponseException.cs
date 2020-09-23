using System;
using System.Net;

namespace CNX.Configs
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException( object v)
        {
            Value = v;
        }
        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;

        public object Value { get; set; }
    }
}
