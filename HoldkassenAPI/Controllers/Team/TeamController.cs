using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HoldkassenAPI.Exceptions;
using HoldkassenAPI.Interfaces.Team;
using HoldkassenAPI.Models.Team.TeamViewModels;

namespace HoldkassenAPI.Controllers.Team
{
    [Authorize]
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

        [ResponseType(typeof(TeamInfo))]
        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateTeam createTeam)
        {
            var result = await _services.Create(createTeam.Name, UserId);
            if (result == null) throw new InternalServerErrorException();
            return Content(HttpStatusCode.Created, new TeamInfo(result));
        }
    }
}
