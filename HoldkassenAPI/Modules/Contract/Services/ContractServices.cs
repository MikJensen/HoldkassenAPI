using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HoldkassenAPI.Modules.Contract.Interfaces;
using HoldkassenAPI.Modules.Contract.Models;
using HoldkassenAPI.Modules.Contract.ViewModels;
using HoldkassenAPI.Modules.Team;
using HoldkassenAPI.Modules.Team.Interfaces;
using HoldkassenAPI.Shared.Exceptions;
using HoldkassenAPI.Shared.Interfaces;

namespace HoldkassenAPI.Modules.Contract.Services
{
    public class ContractServices : IContractServices
    {
        private readonly IContractReadRepo _read;
        private readonly IGenericWriteRepo<Models.Contract> _write;
        public ContractServices(IContractReadRepo read, IGenericWriteRepo<Models.Contract> write)
        {
            _read = read;
            _write = write;
        }

        public async Task<Models.Contract> ApproveContract(string contractId)
        {
            var foundContract = await _read.FindContract(contractId);
            if (foundContract == null)throw new NotFoundException(ContractResources.ContractNotFound);

            foundContract.UpdateApproved(true);

            var succes = await _write.Update(foundContract);
            if (succes > 0) return foundContract;
            throw new InternalServerErrorException();
        }

        public Task<IEnumerable<Models.Contract>> GetContracts(string teamId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Contract>> GetNotAppliedContracts(string teamId)
        {
            throw new NotImplementedException();
        }
    }
}