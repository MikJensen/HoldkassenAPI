using System.ComponentModel.DataAnnotations;

namespace HoldkassenAPI.Modules.Payment.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }

        public double Amount { get; set; }

    }
}