using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoldkassenAPI.Interfaces.Team;
using HoldkassenAPI.Models.Team;
using HoldkassenAPI.Models.Team.TeamViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace HoldkassenAPI.Services
{
    [Authorize]
    public class TeamServices : ITeamServices
    {
        private readonly ITeamReadRepo _read;
        private readonly ITeamWriteRepo _write;

        public TeamServices(ITeamReadRepo readRepo, ITeamWriteRepo writeRepo)
        {
            _read = readRepo;
            _write = writeRepo;
        }

        [AllowAnonymous]
        public async Task<Team> CreateTeam(CreateTeam team)
        {
            var result = await _read.FindTeamByTeamCode(team.TeamCode);
            return null;
        }

        public Task<Team> DeleteTeam(string teamId)
        {
            throw new NotImplementedException();
        }

        public Task<Team> FindTeamCode(string teamId)
        {
            throw new NotImplementedException();
        }

        public Task<Team> UpdateTeam(string teamId)
        {
            throw new NotImplementedException();
        }
    }
}
