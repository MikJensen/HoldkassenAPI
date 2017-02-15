using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HoldkassenAPI.Modules.Account;
using HoldkassenAPI.Modules.Account.Models;
using HoldkassenAPI.Modules.Contract.Models;
using HoldkassenAPI.Modules.Team.Interfaces;
using HoldkassenAPI.Modules.Team.Models;
using HoldkassenAPI.Modules.Team.TeamViewModels;
using HoldkassenAPI.Shared.Exceptions;
using HoldkassenAPI.Shared.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebGrease.Css.Ast.Selectors;

namespace HoldkassenAPI.Modules.Team.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly ITeamReadRepo _read;
        private readonly IGenericWriteRepo<Models.Team> _write;
        private ApplicationUserManager UserManager => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        public TeamServices(ITeamReadRepo read, IGenericWriteRepo<Models.Team> write)
        {
            _read = read;
            _write = write;
        }

        public async Task<Models.Team> Create(string name, string userId)
        {
            var teamName = await _read.FindByName(name);
            if (teamName != null) throw new BadRequestException(TeamResources.NameAlreadyInUse);

            var user = UserManager.FindById(userId);
            if (user == null) throw new NotFoundException(AccountResource.UserNotFound);

            var newTeam = Models.Team.Create(name, userId);

            if (await _write.Create(newTeam) == 0) throw new InternalServerErrorException();

            user.LoggedInAs = newTeam.Contracts.First().Id;
            var userUpdated = await UserManager.UpdateAsync(user);
            //TODO: Maybe other exception
            if (!userUpdated.Succeeded)throw new InternalServerErrorException();

            return newTeam;
        }

        public async Task<Models.Team> GetTeamInfo(string teamId)
        {
            if(teamId == "NoTeam" || teamId == null) throw new BadRequestException(TeamResources.NotAssignedTeam);

            var foundTeam = await _read.Find(teamId);
            if (foundTeam == null) throw new NotFoundException(TeamResources.TeamNotFound);
            return foundTeam;
        }

        public async Task<Models.Team> Update(string teamId, string newName)
        {
            var foundTeam = await _read.Find(teamId);
            if (foundTeam == null) throw new NotFoundException(TeamResources.TeamNotFound);

            var teamName = await _read.FindByName(newName);
            if (teamName != null) throw new BadRequestException(TeamResources.NameAlreadyInUse);

            foundTeam.Update(newName);

            var succes = await _write.Update(foundTeam);
            if (succes > 0) return foundTeam;
            throw new InternalServerErrorException();
        }

        public async Task<Contract.Models.Contract> Apply(string teamCode, string userId)
        {
            var foundContract = await _read.FindTeamContract(teamCode, userId);
            if (foundContract != null)throw new BadRequestException(TeamResources.TeamAlreadyApplied);

            var foundTeam = await _read.FindByCode(teamCode);
            if (foundTeam == null) throw new NotFoundException(TeamResources.TeamNotFound);

            var contract = foundTeam.AddPlayerContract(userId);
            if (contract == null) throw new InternalServerErrorException();

            var succes = await _write.Update(foundTeam);

            if (succes > 0) return contract;
            throw new InternalServerErrorException();
        }
    }
}