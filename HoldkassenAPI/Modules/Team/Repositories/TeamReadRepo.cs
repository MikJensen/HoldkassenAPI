using System;
using System.Data.Entity;
using System.Linq;
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

        public async Task<Models.Team> FindByCode(string teamCode)
        {
            return await _db.Teams.FirstOrDefaultAsync(t => t.TeamCode == teamCode);
        }

        public async Task<Contract.Models.Contract> FindTeamContract(string teamCode, string userId)
        {
            return await _db.Teams.Where(t => t.TeamCode == teamCode).SelectMany(t => t.Contracts).FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Models.Team> FindByName(string name)
        {
            return await _db.Teams.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}