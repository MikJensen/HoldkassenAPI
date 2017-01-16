using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Interfaces;
using HoldkassenAPI.Interfaces.Team;
using HoldkassenAPI.Models.Team;

namespace HoldkassenAPI.Repositories.Write
{
    public class TeamWriteRepo : GenericWriteRepo<Team>, ITeamWriteRepo
    {
        public TeamWriteRepo(HoldkassenDbContext db) : base(db)
        {
        }
    }
}