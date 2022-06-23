using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class UserDetail
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]              // MM/DD/YY
        public string UserDateCreated { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]              // MM/DD/YY
        public string DateOfBirth { get; set; }

    }
}