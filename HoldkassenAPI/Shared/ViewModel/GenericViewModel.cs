using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Shared.ViewModel
{
    public class GenericViewModel
    {
        [Required, StringLength(36, MinimumLength = 36)]
        public string Id { get; set; }
    }
}