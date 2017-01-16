using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Models.Payment
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }

        public double Amount { get; set; }

    }
}