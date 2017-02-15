using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using HoldkassenAPI.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace HoldkassenAPI.Modules.Account.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        // Should have PlayerContractId when user is in a team.
        public string LoggedInAs { get; set; } = "NoTeam";

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            //userIdentity.AddClaim(new Claim("LoggedInAs", LoggedInAs));

            return userIdentity;
        }
    }
}