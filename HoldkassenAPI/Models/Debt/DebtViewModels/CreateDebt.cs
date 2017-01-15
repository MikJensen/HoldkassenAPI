using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Models.Debt.DebtViewModels
{
    public class CreateDebt
    {
        public string FineId { get; set; }

        public string PlayerContractId { get; set; }

        public string SeasonId { get; set; }
    }
}