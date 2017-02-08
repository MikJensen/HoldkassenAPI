using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Modules.Team.TeamViewModels
{
    public class GetTeam
    {
        [Required]
        public string TeamCode { get; set; }
    }
}