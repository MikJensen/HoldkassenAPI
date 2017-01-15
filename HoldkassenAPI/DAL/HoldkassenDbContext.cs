using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;
using HoldkassenAPI.Models.Account.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HoldkassenAPI.DAL
{
    public class HoldkassenDbContext : IdentityDbContext<ApplicationUser>
    {
        public HoldkassenDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
             .HasMany(c => c.Teams)
             .WithMany(i => i.Users)
             .Map(t => t.MapLeftKey("ApplicationUserId")
                 .MapRightKey("Id")
                 .ToTable("UserTeams"));

        }

        public static HoldkassenDbContext Create()
        {
            return new HoldkassenDbContext();
        }
    }
}