﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Utilities;

namespace HoldkassenAPI.Filters
{
    public class ValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.Any() && !actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    actionContext.ModelState);
            }
            foreach (var key in actionContext.ActionArguments.Keys)
            {
                if (actionContext.ActionArguments[key] == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        Utils.ReturnableErrorMessage($"{Resources.Exceptions.MissingObject} {key}"));
                }
            }
        }
    }
}