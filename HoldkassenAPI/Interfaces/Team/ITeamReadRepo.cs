using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldkassenAPI.Interfaces.Team
{
    public interface ITeamReadRepo
    {
        Task<Models.Team.Team> FindByName(string name);
    }
}
