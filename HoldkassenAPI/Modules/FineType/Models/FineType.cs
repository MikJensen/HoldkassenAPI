using System.ComponentModel.DataAnnotations;

namespace HoldkassenAPI.Modules.FineType.Models
{
    public class FineType
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}