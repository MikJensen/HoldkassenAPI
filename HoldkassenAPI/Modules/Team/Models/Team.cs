using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace HoldkassenAPI.Modules.Team.Models
{
    public class Team
    {
        [Key]
        [Required, StringLength(36, MinimumLength = 36)]
        public string Id { get; private set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; private set; }

        [Required, StringLength(15, MinimumLength = 15)]
        public string TeamCode { get; private set; }

        public virtual ICollection<PlayerContract.Models.PlayerContract> Contracts { get; private set; }

        public static Team Create(string name, string userId)
        {
            var id = Guid.NewGuid().ToString();
            var teamCode = name.Replace(" ", "").ToLower().Substring(0, 3) + DateTime.Now.ToString("ddMMyyHHmmss");
            var contract = PlayerContract.Models.PlayerContract.Create(true, teamCode, id, userId, true);
            var t = new Team
            {
                Id = id,
                Name = name,
                TeamCode = teamCode,
                Contracts = new List<PlayerContract.Models.PlayerContract> {contract}
            };
            
            return t;
        }

        public void Update(string name)
        {
            if (Name.Equals(name)) return;
            Name = name;
            TeamCode = name + TeamCode.Substring(TeamCode.Length - 12, 12);
        }

        public void AddPlayerContract(string userId)
        {
            var contract = PlayerContract.Models.PlayerContract.Create(false, TeamCode, Id, userId, false);
            Contracts.Add(contract);
        }
    }
}