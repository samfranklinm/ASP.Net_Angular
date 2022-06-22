using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PMId { get; set; }
        [Required]                                      // field below is required, cannot be left null
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]

        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]              // Expiration date in the format of MM/YY = 5 characters
        public string ExpirationDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]              // Expiration date in the format of MM/YY
        public string CVV { get; set; }
    }
}
