using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Models.Fine
{
    public class Fine
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public FineType.FineType FineType { get; set; }
    }
}