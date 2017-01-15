using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HoldkassenAPI.Models.Account;

namespace HoldkassenAPI.Models.Team
{
    public class Team
    {
        [Key, StringLength(36, MinimumLength = 36)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string TeamCode { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public static Team Create(string name)
        {
            var t = new Team()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                TeamCode = name.ToLower().Trim() + DateTime.Now.ToString("ddMMyyHHmmss")
            };
            return t;
        }

        public void Update(string name)
        {
            if (Name.Equals(name)) return;
            Name = name;
            TeamCode = Name + TeamCode.Substring(TeamCode.Length - 12, 12);
        }
    }
}