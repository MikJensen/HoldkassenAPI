using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoldkassenAPI.Models.Season
{
    public class Season
    {
        [Key]
        public string Id { get; private set; }

        public DateTime SeasonStart { get; private set; }

        public DateTime SeasonEnd { get; private set; }

        public static Season Create(DateTime seasonStart, DateTime seasonEnd)
        {
            var season = new Season()
            {
                Id = Guid.NewGuid().ToString(),
                SeasonStart = seasonStart,
                SeasonEnd = seasonEnd
            };
            return season;
        }
    }
}