using System.Threading.Tasks;
using HoldkassenAPI.Modules.Team.TeamViewModels;

namespace HoldkassenAPI.Modules.Team.Interfaces
{
    public interface ITeamServices
    {
        Task<Modules.Team.Models.Team> GetTeamInfo(string teamId);
        Task<Modules.Team.Models.Team> Create(string name, string userId);
        Task<Modules.Team.Models.Team> Update(string teamId, string newName);
    }
}
