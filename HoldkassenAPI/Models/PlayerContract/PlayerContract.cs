using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;
using HoldkassenAPI.Models.Debt.DebtViewModels;

namespace HoldkassenAPI.Models.PlayerContract
{
    public class PlayerContract
    {
        [Key]
        public string Id { get; private set; }

        public bool Approved { get; private set; }

        public string TeamCode { get; private set; }

        public bool TeamAdmin { get; private set; }

        [ForeignKey(nameof(Team))]
        public string TeamId { get; private set; }
        public Team.Team Team { get; private set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; private set; }
        public ApplicationUser User { get; private set; }

        public ICollection<Debt.Debt> Debts { get; set; }

        public static PlayerContract Create(
            bool approved, string teamCode, string teamId, string userId, bool admin)
        {
            var contract = new PlayerContract()
            {
                Id = Guid.NewGuid().ToString(),
                Approved = approved,
                TeamCode = teamCode,
                TeamAdmin = admin,
                TeamId = teamId,
                UserId = userId
            };
            return contract;
        }

        public void AddDebt(string fineId, string teamId, string seasonId)
        {
            var newDebt = Debt.Debt.Create(fineId, teamId, seasonId);
            Debts.Add(newDebt);
        }
    }
}