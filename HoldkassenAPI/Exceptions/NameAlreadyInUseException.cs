using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Spring.Globalization;

namespace HoldkassenAPI.Exceptions
{
    public class NameAlreadyInUseException : BaseException
    {
        public NameAlreadyInUseException(string resource) : base(resource, HttpStatusCode.BadRequest)
        {
        }
    }
}