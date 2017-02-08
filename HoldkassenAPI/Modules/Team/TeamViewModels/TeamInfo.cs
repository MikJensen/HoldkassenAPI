using System.Collections.Generic;
using System.Linq;

namespace HoldkassenAPI.Modules.Team.TeamViewModels
{
    public class TeamInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeamCode { get; set; }
        public ICollection<PlayerContract.Models.PlayerContract> Contracts { get; set; }

        public TeamInfo(Models.Team team)
        {
            Id = team.Id;
            Name = team.Name;
            TeamCode = team.TeamCode;
            Contracts = team.Contracts.Select(e => PlayerContract.Models.PlayerContract.Create(
                e.Approved, e.TeamCode, e.TeamId, e.UserId, e.TeamAdmin)).ToList();
        }
    }
}