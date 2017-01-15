using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoldkassenAPI.Data;
using HoldkassenAPI.Interfaces.Team;
using HoldkassenAPI.Models.Team;

namespace HoldkassenAPI.Repositories.Write
{
    public class TeamWriteRepo : GenericWriteRepo<Team>, ITeamWriteRepo
    {
        public TeamWriteRepo(ApplicationDbContext db) : base(db)
        {
        }
    }
}
