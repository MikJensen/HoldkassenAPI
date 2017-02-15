using System.Collections.Generic;
using System.Threading.Tasks;
using HoldkassenAPI.Modules.Team.TeamViewModels;

namespace HoldkassenAPI.Modules.Team.Interfaces
{
    public interface ITeamServices
    {
        Task<Models.Team> GetTeamInfo(string teamId);
        Task<Models.Team> Create(string name, string userId);
        Task<Models.Team> Update(string teamId, string newName);
        Task<Contract.Models.Contract> Apply(string teamCode, string userId);
    }
}
