using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HoldkassenAPI.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource) : base(resource, HttpStatusCode.NotFound)
        {
        }
    }
}