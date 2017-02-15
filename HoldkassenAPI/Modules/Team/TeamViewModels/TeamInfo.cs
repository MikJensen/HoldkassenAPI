using System.Collections.Generic;
using System.Linq;

namespace HoldkassenAPI.Modules.Team.TeamViewModels
{
    public class TeamInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeamCode { get; set; }
        public ICollection<Contract> Contracts { get; set; }

        public TeamInfo(Models.Team team)
        {
            Id = team.Id;
            Name = team.Name;
            TeamCode = team.TeamCode;
            Contracts = team.Contracts.Select(e => new Contract
            {
                Id = e.Id,
                Approved = e.Approved,
                TeamCode = e.TeamCode,
                TeamAdmin = e.TeamAdmin,
                TeamId = e.TeamId,
                UserId = e.UserId
            }).ToList();
        }
    }

    public class Contract
    {
        public string Id { get; set; }

        public bool Approved { get; set; }

        public string TeamCode { get; set; }

        public bool TeamAdmin { get; set; }

        public string TeamId { get; set; }

        public string UserId { get; set; }
    }
}