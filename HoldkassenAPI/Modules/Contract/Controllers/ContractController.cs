using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HoldkassenAPI.Attributes;
using HoldkassenAPI.Modules.Contract.Interfaces;
using HoldkassenAPI.Modules.Contract.ViewModels;
using HoldkassenAPI.Modules.Team.TeamViewModels;
using HoldkassenAPI.Shared.Controllers;
using HoldkassenAPI.Shared.ViewModel;

namespace HoldkassenAPI.Modules.Contract.Controllers
{
    [Authorize]
    [RoutePrefix("api/Contract")]
    public class ContractController : CoreController
    {
        private readonly IContractServices _services;

        public ContractController(IContractServices services)
        {
            _services = services;
        }

        public ContractController()
        {
            
        }

        [ResponseStatusCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(ShowContract))]
        [Route("ApproveContract")]
        [HttpPost]
        public async Task<IHttpActionResult> ApproveContract(GenericViewModel contract)
        {
            var result = await _services.ApproveContract(contract.Id);
            return Content(HttpStatusCode.OK, new ShowContract(result));
        }

    }
}
