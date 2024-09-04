using System.ComponentModel.DataAnnotations;

namespace authTask.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
