using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Modules.Contract.ViewModels
{
    public class ShowContract
    {
        public string Id { get; set; }

        public bool Approved { get; set; }

        public string TeamCode { get; set; }

        public bool TeamAdmin { get; set; }

        public string TeamId { get; set; }

        public string UserId { get; set; }

        public ShowContract(Models.Contract contract)
        {
            Id = contract.Id;
            Approved = contract.Approved;
            TeamCode = contract.TeamCode;
            TeamAdmin = contract.TeamAdmin;
            TeamId = contract.TeamId;
            UserId = contract.UserId;
        }
    }
}