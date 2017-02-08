using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using HoldkassenAPI.DAL;
using Microsoft.AspNet.Identity;

namespace HoldkassenAPI.Controllers
{
    public class CoreController : ApiController
    {
        private readonly HoldkassenDbContext _db;
        public CoreController()
        {
            _db = HoldkassenDbContext.Create();
        }

        protected ClaimsPrincipal Principal => Request.GetRequestContext().Principal as ClaimsPrincipal;

        protected string CurrentUser => Principal.Claims.Single(c => c.Type == "LoggedInAs").Value;

        protected string TeamId {
            get { return _db.PlayerContracts.FirstOrDefault(e => e.Id == CurrentUser)?.TeamId; }
        }

        protected string UserId => Principal.Identity.GetUserId();

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
