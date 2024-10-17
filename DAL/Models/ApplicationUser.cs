using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Age { get; set; }
        public string? Address { get; set; }

        public string? Email { get; set; }

        public int? gender { get; set; }

        public string? MedicalHistory { get; set; }

        public string? Location { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public string? Specialty { get; set; }
    }
}
