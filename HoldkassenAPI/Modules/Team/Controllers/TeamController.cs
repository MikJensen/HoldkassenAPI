using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HoldkassenAPI.Attributes;
using HoldkassenAPI.Controllers;
using HoldkassenAPI.Exceptions;
using HoldkassenAPI.Modules.Team.Interfaces;
using HoldkassenAPI.Modules.Team.TeamViewModels;

namespace HoldkassenAPI.Modules.Team.Controllers
{
    [Authorize]
    [RoutePrefix("api/Team")]
    public class TeamController : CoreController
    {
        private readonly ITeamServices _services;
        public TeamController(ITeamServices services)
        {
            _services = services;
        }

        public TeamController()
        {
            
        }

        [ResponseStatusCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(TeamInfo))]
        [HttpGet]
        public async Task<IHttpActionResult> GetTeamInfo()
        {
            var result = await _services.GetTeamInfo(TeamId);
            return Content(HttpStatusCode.OK, new TeamInfo(result));
        }

        [ResponseStatusCodes(HttpStatusCode.Created)]
        [ResponseType(typeof(TeamInfo))]
        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateTeam createTeam)
        {
            var result = await _services.Create(createTeam.Name, UserId);
            if (result == null) throw new InternalServerErrorException();
            return Content(HttpStatusCode.Created, new TeamInfo(result));
            
        }

        [ResponseStatusCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(TeamInfo))]
        [HttpPut]
        public async Task<IHttpActionResult> Update(UpdateTeam updateTeam)
        {
            var result = await _services.Update(updateTeam.Id, updateTeam.newName);
            if (result == null) throw new InternalServerErrorException();
            return Content(HttpStatusCode.OK, new TeamInfo(result));

        }
    }
}
