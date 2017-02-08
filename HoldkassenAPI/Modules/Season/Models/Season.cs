using System;
using System.ComponentModel.DataAnnotations;

namespace HoldkassenAPI.Modules.Season.Models
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