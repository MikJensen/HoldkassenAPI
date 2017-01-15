using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoldkassenAPI.Data;
using HoldkassenAPI.Interfaces.Team;
using Microsoft.EntityFrameworkCore;

namespace HoldkassenAPI.Repositories.Read
{
    public class TeamReadRepo : ITeamReadRepo
    {
        private readonly ApplicationDbContext _db;
        public TeamReadRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> FindTeamByTeamCode(string teamId)
        {
            var team = await _db.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
            return team.TeamCode;
        }
    }
}
