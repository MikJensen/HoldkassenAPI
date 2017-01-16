using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;

namespace HoldkassenAPI.Models.Team.TeamViewModels
{
    public class TeamAndUserInfo : TeamInfo
    {
        public TeamAndUserInfo(Team team, ApplicationUser user) : base(team)
        {
            User = new UserInfo
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Phone = user.Phone
            };
        }

        public UserInfo User { get; set; }
    }

    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Phone { get; set; }
    }
}