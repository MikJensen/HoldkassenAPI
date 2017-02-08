using System.Threading.Tasks;

namespace HoldkassenAPI.Modules.Team.Interfaces
{
    public interface ITeamReadRepo
    {
        Task<Models.Team> FindByName(string name);
        Task<Models.Team> Find(string teamId);
    }
}
