using HoldkassenAPI.Modules.Account;
using HoldkassenAPI.Modules.Account.Models;

namespace HoldkassenAPI.Modules.Team.TeamViewModels
{
    public class TeamAndUserInfo : TeamInfo
    {
        public TeamAndUserInfo(Models.Team team, ApplicationUser user) : base(team)
        {
            User = new UserInfo
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Phone = user.PhoneNumber
            };
        }

        public UserInfo User { get; set; }
    }

    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}