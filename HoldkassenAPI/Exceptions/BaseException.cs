using System;
using System.Net;

namespace HoldkassenAPI.Exceptions
{
    public class BaseException : Exception
    {
        public HttpStatusCode StatusCode;
        protected BaseException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}