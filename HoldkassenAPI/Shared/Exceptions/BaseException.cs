using System;
using System.Net;

namespace HoldkassenAPI.Shared.Exceptions
{
    public class BaseException : Exception
    {
        public HttpStatusCode StatusCode;
        protected BaseException(string resource, HttpStatusCode statusCode) : base(resource)
        {
            StatusCode = statusCode;
        }
    }
}