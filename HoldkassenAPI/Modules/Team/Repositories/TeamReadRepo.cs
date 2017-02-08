using System;
using System.Data.Entity;
using System.Threading.Tasks;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Modules.Team.Interfaces;
using HoldkassenAPI.Modules.Team.Models;

namespace HoldkassenAPI.Modules.Team.Repositories
{
    public class TeamReadRepo : ITeamReadRepo
    {
        private readonly HoldkassenDbContext _db;
        public TeamReadRepo(HoldkassenDbContext db)
        {
            _db = db;
        }

        public async Task<Models.Team> Find(string teamId)
        {
            return await _db.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
        }

        public async Task<Models.Team> FindByName(string name)
        {
            return await _db.Teams.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}