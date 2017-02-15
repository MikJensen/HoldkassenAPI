using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HoldkassenAPI.DAL;
using Microsoft.AspNet.Identity;
using Spring.Validation;

namespace HoldkassenAPI.Shared.Filters
{
    public class IsMemberFilter : AuthorizationFilterAttribute
    {
        private readonly HoldkassenDbContext _db;

        public IsMemberFilter(HoldkassenDbContext db)
        {
            _db = db;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = _db.Users.FirstOrDefaultAsync(u => u.Id == userId).Result;

            if (user.LoggedInAs == "NoTeam")
            {
                
            }
        }
    }
}