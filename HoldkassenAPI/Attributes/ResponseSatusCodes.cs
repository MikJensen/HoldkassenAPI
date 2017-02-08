using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HoldkassenAPI.Attributes
{
    // Method attribute because we don't want it on any controller.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ResponseStatusCodes : Attribute
    {
        public ResponseStatusCodes(params HttpStatusCode[] statusCodes)
        {
            StatusCodes = statusCodes;
        }

        public HttpStatusCode[] StatusCodes { get; set; }
    }
}