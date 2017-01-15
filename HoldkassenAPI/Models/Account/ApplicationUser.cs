using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HoldkassenAPI.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public int Phone { get; set; }

        public string LoggedInAs { get; set; } = "NoTeam";

        public ICollection<Team.Team> Teams { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}