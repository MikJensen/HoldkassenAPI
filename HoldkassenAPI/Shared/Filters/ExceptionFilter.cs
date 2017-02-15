using System.Net.Http;
using System.Web.Http.Filters;
using HoldkassenAPI.Shared.Exceptions;
using HoldkassenAPI.Shared.Utilities;

namespace HoldkassenAPI.Shared.Filters
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