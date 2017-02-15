using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using HoldkassenAPI.Modules.Account.Models;
using Newtonsoft.Json;

namespace HoldkassenAPI.Modules.Contract.Models
{
    public class Contract
    {
        [Key]
        public string Id { get; private set; }

        public bool Approved { get; private set; }

        public string TeamCode { get; private set; }

        public bool TeamAdmin { get; private set; }

        [ForeignKey(nameof(Team))]
        public string TeamId { get; private set; }
        public Team.Models.Team Team { get; private set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; private set; }
        public ApplicationUser User { get; private set; }
        
        public ICollection<Debt.Models.Debt> Debts { get; set; }

        public static Contract Create(
            bool approved, string teamCode, string teamId, string userId, bool admin)
        {
            var contract = new Contract()
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

        public void UpdateApproved(bool isApproved)
        {
            if (Approved.Equals(isApproved)) return;
            Approved = isApproved;
        }

        public void AddDebt(string fineId, string teamId, string seasonId)
        {
            var newDebt = Debt.Models.Debt.Create(fineId, teamId, seasonId);
            Debts.Add(newDebt);
        }
    }
}