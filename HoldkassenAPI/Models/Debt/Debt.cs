using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Debt.DebtViewModels;

namespace HoldkassenAPI.Models.Debt
{
    public class Debt
    {
        public string Id { get; private set; }

        [ForeignKey(nameof(Fine))]
        public string FineId { get; private set; }
        public Fine.Fine Fine { get; private set; }

        [ForeignKey(nameof(PlayerContract))]
        public string PlayerContractId { get; private set; }
        public PlayerContract.PlayerContract PlayerContract { get; private set; }

        [ForeignKey(nameof(Season))]
        public string SeasonId { get; private set; }
        public Season.Season Season { get; private set; }

        public static Debt Create(string fineId, string playerContractId, string seasonId)
        {
            var debt = new Debt()
            {
                Id = Guid.NewGuid().ToString(),
                FineId = fineId,
                PlayerContractId = playerContractId,
                SeasonId = seasonId
            };
            return debt;
        }
    }
}