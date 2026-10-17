using System.ComponentModel.DataAnnotations;

namespace LoginRegistrationApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(100)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Range(0, 100000000)]
        public decimal Salary { get; set; }
    }
}