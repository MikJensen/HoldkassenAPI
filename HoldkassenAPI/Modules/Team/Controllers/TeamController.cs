using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HoldkassenAPI.Attributes;
using HoldkassenAPI.Modules.Team.Interfaces;
using HoldkassenAPI.Modules.Team.TeamViewModels;
using HoldkassenAPI.Shared.Controllers;
using HoldkassenAPI.Shared.Exceptions;

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

        public TeamController(){}

        [ResponseStatusCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(TeamInfo))]
        [Route("GetTeamInfo")]
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
            return Content(HttpStatusCode.Created, new TeamInfo(result));
            
        }

        [ResponseStatusCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(TeamInfo))]
        [Route("Update")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(UpdateTeam updateTeam)
        {
            var result = await _services.Update(updateTeam.Id, updateTeam.NewName);
            return Content(HttpStatusCode.OK, new TeamInfo(result));

        }

        [ResponseStatusCodes(HttpStatusCode.NoContent)]
        [Route("Apply")]
        [HttpPost]
        public async Task<IHttpActionResult> Apply(GetTeam team)
        {
            await _services.Apply(team.TeamCode, UserId);
            return Content(HttpStatusCode.NoContent, "");
        }
    }
}
