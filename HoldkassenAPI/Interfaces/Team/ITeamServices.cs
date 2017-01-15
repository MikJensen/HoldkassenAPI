using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoldkassenAPI.Models.Team;
using HoldkassenAPI.Models.Team.TeamViewModels;

namespace HoldkassenAPI.Interfaces.Team
{
    public interface ITeamServices
    {
        Task<Models.Team.Team> FindTeamCode(string teamId);
        Task<Models.Team.Team> CreateTeam(CreateTeam team);
        Task<Models.Team.Team> UpdateTeam(string teamId);
        Task<Models.Team.Team> DeleteTeam(string teamId);
    }
}
