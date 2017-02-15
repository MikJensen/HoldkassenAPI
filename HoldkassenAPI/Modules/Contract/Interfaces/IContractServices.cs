using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HoldkassenAPI.Modules.Contract.ViewModels;

namespace HoldkassenAPI.Modules.Contract.Interfaces
{
    public interface IContractServices
    {
        Task<IEnumerable<Models.Contract>> GetContracts(string teamId);
        Task<IEnumerable<Models.Contract>> GetNotAppliedContracts(string teamId);
        Task<Models.Contract> ApproveContract(string contractId);
    }
}