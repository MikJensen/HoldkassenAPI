using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;
using HoldkassenAPI.Models.Debt;
using HoldkassenAPI.Models.Fine;
using HoldkassenAPI.Models.FineType;
using HoldkassenAPI.Models.Payment;
using HoldkassenAPI.Models.PlayerContract;
using HoldkassenAPI.Models.Season;
using HoldkassenAPI.Models.Team;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HoldkassenAPI.DAL
{
    public class HoldkassenDbContext : IdentityDbContext<ApplicationUser>
    {
        public HoldkassenDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FineType> FineTypes { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<PlayerContract> PlayerContracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public static HoldkassenDbContext Create()
        {
            return new HoldkassenDbContext();
        }
    }
}