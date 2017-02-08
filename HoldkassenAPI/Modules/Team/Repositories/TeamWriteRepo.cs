using HoldkassenAPI.DAL;
using HoldkassenAPI.Modules.Team.Interfaces;

namespace HoldkassenAPI.Modules.Team.Repositories
{
    public class TeamWriteRepo : GenericWriteRepo<Models.Team>, ITeamWriteRepo
    {
        public TeamWriteRepo(HoldkassenDbContext db) : base(db)
        {
        }
    }
}