using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HoldkassenAPI.Exceptions;
using HoldkassenAPI.Interfaces.Team;
using HoldkassenAPI.Models.PlayerContract;
using HoldkassenAPI.Models.Team;
using HoldkassenAPI.Models.Team.TeamViewModels;
using Spring.Web.UI.Controls;

namespace HoldkassenAPI.Services.Team
{
    public class TeamServices : ITeamServices
    {
        private readonly ITeamReadRepo _read;
        private readonly ITeamWriteRepo _write;
        public TeamServices(ITeamReadRepo read, ITeamWriteRepo write)
        {
            _read = read;
            _write = write;
        }

        public async Task<Models.Team.Team> Create(string name, string userId)
        {
            var teamName = await _read.FindByName(name);
            if (teamName != null) throw new NameAlreadyInUseException(Resources.TeamResources.NameAlreadyInUse);

            var newTeam = Models.Team.Team.Create(name);

            newTeam.Contracts.Add(PlayerContract.Create(true, newTeam.TeamCode, newTeam.Id, userId, true));

            var succes = await _write.Create(newTeam);
            if (succes > 0) return newTeam;
            throw new InternalServerErrorException();
        }

        public Task<Models.Team.Team> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Team.Team> GetTeamInfo(string teamCode)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Team.Team> Update()
        {
            throw new NotImplementedException();
        }
    }
}