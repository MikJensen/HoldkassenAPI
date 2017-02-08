using System.Web.Http.Filters;
using System.Net.Http;
using HoldkassenAPI.Exceptions;
using HoldkassenAPI.Utilities;

namespace HoldkassenAPI.Filters
{
    public class ExceptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext action)
        {
            if (action.Exception?.GetBaseException() is BaseException)
            {
                var e = (BaseException)action.Exception;
                action.Response = action.Request.CreateResponse(e.StatusCode,Utils.ReturnableErrorMessage(e.Message));
            }
        }
    }
}