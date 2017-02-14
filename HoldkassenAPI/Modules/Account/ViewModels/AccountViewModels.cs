using System.Collections.Generic;
using System.Linq;
using HoldkassenAPI.Modules.Account.Models;

namespace HoldkassenAPI.Modules.Account.ViewModels
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        public string LoggedInAs { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }

        public ICollection<PlayerContract.Models.PlayerContract> Contracts { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
