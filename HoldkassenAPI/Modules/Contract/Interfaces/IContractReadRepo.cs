using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldkassenAPI.Modules.Contract.Interfaces
{
    public interface IContractReadRepo
    {
        Task<Models.Contract> FindTeamContracts(string teamId, bool approved);
        Task<Models.Contract> FindPlayerContracts(string userId);
        Task<Models.Contract> FindContract(string contractId);
    }
}
