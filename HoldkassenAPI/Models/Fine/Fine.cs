using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Models.Fine
{
    public class Fine
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string FineTypeId { get; set; }
        public FineType.FineType FineType { get; set; }
    }
}