using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Spring.Globalization;

namespace HoldkassenAPI.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string resource) : base(resource, HttpStatusCode.BadRequest)
        {
        }
    }
}