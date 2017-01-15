using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoldkassenAPI.Interfaces.Team
{
    public interface ITeamReadRepo
    {
        Task<string> FindTeamByTeamCode(string teamId);
    }
}
