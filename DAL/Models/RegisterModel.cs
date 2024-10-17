using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GradPro.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }

        public string? Email { get; set; }

        public int? gender { get; set; }

        public string? phoneNumber { get; set; }

        public string? MedicalHistory { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string? Location { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public string? Specialty { get; set; }  
    }
}
