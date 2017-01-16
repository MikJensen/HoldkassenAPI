using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HoldkassenAPI.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException() : base(Resources.Exceptions.InternalServerError, HttpStatusCode.InternalServerError)
        {
            
        }
    }
}