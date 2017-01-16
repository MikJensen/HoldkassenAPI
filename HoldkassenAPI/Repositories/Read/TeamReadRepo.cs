using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Interfaces.Team;
using HoldkassenAPI.Models.Team;

namespace HoldkassenAPI.Repositories.Read
{
    public class TeamReadRepo : ITeamReadRepo
    {
        private readonly HoldkassenDbContext _db;
        public TeamReadRepo(HoldkassenDbContext db)
        {
            _db = db;
        }
        public async Task<Team> FindByName(string name)
        {
            return await _db.Teams.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}