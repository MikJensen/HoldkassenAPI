using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using Spring.Threading;
using System.Net.Http;
using HoldkassenAPI.Exceptions;

namespace HoldkassenAPI.Filters
{
    public class ExceptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext action)
        {
            if (action.Exception?.GetBaseException() is BaseException)
            {
                var e = (BaseException)action.Exception;
                action.Response = action.Request.CreateResponse(e.StatusCode,e.Message);
            }
        }
    }
}