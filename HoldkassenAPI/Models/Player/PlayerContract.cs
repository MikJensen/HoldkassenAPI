using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;

namespace HoldkassenAPI.Models.Player
{
    public class PlayerContract
    {
        public string Id { get; set; }

        public bool Approved { get; set; }

        public string TeamCode { get; set; }

        [StringLength(36, MinimumLength = 36)]
        public string TeamId { get; set; } = "NoTeam";

        [ForeignKey(nameof(Player)), StringLength(36, MinimumLength = 36)]
        public string UserId { get; set; }
        public virtual ApplicationUser Player { get; set; }
    }
}