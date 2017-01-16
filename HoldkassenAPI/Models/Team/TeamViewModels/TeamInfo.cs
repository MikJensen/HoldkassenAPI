using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;

namespace HoldkassenAPI.Models.Team.TeamViewModels
{
    public class TeamInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeamCode { get; set; }
        public ICollection<PlayerContract.PlayerContract> Contracts { get; set; }

        public TeamInfo(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            TeamCode = team.TeamCode;
            Contracts = team.Contracts.Select(e => PlayerContract.PlayerContract.Create(
                e.Approved, e.TeamCode, e.TeamId, e.UserId, e.TeamAdmin)).ToList();
        }
    }
}