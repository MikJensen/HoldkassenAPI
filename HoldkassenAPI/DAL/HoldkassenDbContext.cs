using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HoldkassenAPI.Modules.Account;
using HoldkassenAPI.Modules.Account.Models;
using HoldkassenAPI.Modules.Debt.Models;
using HoldkassenAPI.Modules.Fine.Models;
using HoldkassenAPI.Modules.FineType.Models;
using HoldkassenAPI.Modules.Payment.Models;
using HoldkassenAPI.Modules.PlayerContract.Models;
using HoldkassenAPI.Modules.Season.Models;
using HoldkassenAPI.Modules.Team.Models;
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

            modelBuilder.Entity<PlayerContract>().HasMany(d => d.Debts);

            modelBuilder.Entity<Team>().HasMany(p => p.Contracts);

        }

        public static HoldkassenDbContext Create()
        {
            return new HoldkassenDbContext();
        }
    }
}