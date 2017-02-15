﻿using System.Linq;
using System.Web;
using System.Web.Http;
using HoldkassenAPI.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HoldkassenAPI.Shared.Controllers
{
    public class CoreController : ApiController
    {
        protected readonly HoldkassenDbContext Db;
        public CoreController()
        {
            Db = HoldkassenDbContext.Create();
        }

        protected ApplicationUserManager UserManager
            => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        protected string CurrentUser => UserManager.FindById(HttpContext.Current.User.Identity.GetUserId()).LoggedInAs;

        protected string TeamId {
            get { return Db.Contracts.FirstOrDefault(c => c.Id == CurrentUser)?.TeamId; }
        }

        protected string UserId => UserManager.FindById(HttpContext.Current.User.Identity.GetUserId()).Id;

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