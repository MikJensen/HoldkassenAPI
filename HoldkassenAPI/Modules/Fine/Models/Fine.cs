using System.ComponentModel.DataAnnotations;

namespace HoldkassenAPI.Modules.Fine.Models
{
    public class Fine
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string FineTypeId { get; set; }
        public FineType.Models.FineType FineType { get; set; }
    }
}