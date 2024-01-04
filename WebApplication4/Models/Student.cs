using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public partial class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(11, ErrorMessage = "Phone must be 11 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must contain only digits")]
        public string? Phone { get; set; }
    }
}
