using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoldkassenAPI.Models.Team.TeamViewModels;

namespace HoldkassenAPI.Interfaces.Team
{
    public interface ITeamServices
    {
        Task<Models.Team.Team> GetTeamInfo(string teamCode);
        Task<Models.Team.Team> Create(string name, string userId);
        Task<Models.Team.Team> Update();
        Task<Models.Team.Team> Delete();
    }
}
