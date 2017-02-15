using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Modules.Contract.Interfaces;
using HoldkassenAPI.Modules.Contract.Models;

namespace HoldkassenAPI.Modules.Contract.Repositories
{
    public class ContractReadRepo : IContractReadRepo
    {
        private readonly HoldkassenDbContext _db;
        public ContractReadRepo(HoldkassenDbContext db)
        {
            _db = db;
        }

        public Task<Models.Contract> FindContract(string contractId)
        {
            return _db.Contracts.FirstOrDefaultAsync(c => c.Id == contractId);
        }

        public Task<Models.Contract> FindPlayerContracts(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Contract> FindTeamContracts(string teamId, bool approved)
        {
            throw new NotImplementedException();
        }
    }
}