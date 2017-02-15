using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoldkassenAPI.Modules.Team.Interfaces
{
    public interface ITeamReadRepo
    {
        Task<Models.Team> FindByName(string name);
        Task<Models.Team> Find(string teamId);
        Task<Models.Team> FindByCode(string teamCode);
        Task<Contract.Models.Contract> FindTeamContract(string teamCode, string userId);
    }
}
