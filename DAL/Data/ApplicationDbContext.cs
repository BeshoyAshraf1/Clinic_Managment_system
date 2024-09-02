using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradPro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Staff> Staffs {  get; set; }
        
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Pharmacy> pharmacies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users","security");
            modelBuilder.Entity<IdentityRole>()
            .ToTable("Roles", "security");
            modelBuilder.Entity<IdentityUserRole<string>>()
            .ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>()
           .ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>()
.ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>()
.ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<string>>()
.ToTable("UserTokens", "security");

            // Seed Clinics
            modelBuilder.Entity<Clinic>().HasData(
                new Clinic { ID = 1, Name = "City Health Clinic", Address = "123 Main St", PhoneNumber = "123-456-7890", Email = "info@cityhealth.com", Location = "Downtown" },
                new Clinic { ID = 2, Name = "Suburban Health Clinic", Address = "456 Elm St", PhoneNumber = "987-654-3210", Email = "contact@suburbanhealth.com", Location = "Suburb" }
            );

            // Seed Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { ID = 1, Name = "Dr. John Doe", Position = StaffPosition.Doctor, PhoneNumber = "555-1234", Email = "johndoe@clinic.com", Department = "Cardiology", salary = 150000, Specialty = Specialty.Cardiology, ClinicID = 1 },
                new Staff { ID = 2, Name = "Dr. Jane Smith", Position = StaffPosition.Doctor, PhoneNumber = "555-5678", Email = "janesmith@clinic.com", Department = "Dermatology", salary = 140000, Specialty = Specialty.Dermatology, ClinicID = 1 },
                new Staff { ID = 3, Name = "Dr. Emily Brown", Position = StaffPosition.Doctor, PhoneNumber = "555-8765", Email = "emilybrown@clinic.com", Department = "Neurology", salary = 155000, Specialty = Specialty.Neurology, ClinicID = 2 }
            );

            // Seed Doctor Schedules
            modelBuilder.Entity<DoctorSchedule>().HasData(
                new DoctorSchedule { Id = 1, StaffId = 1, Date = DateTime.Today.AddDays(1), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 0, 0), MaxPatients = 10, price = 200 },
                new DoctorSchedule { Id = 2, StaffId = 2, Date = DateTime.Today.AddDays(2), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(16, 0, 0), MaxPatients = 8, price = 180 },
                new DoctorSchedule { Id = 3, StaffId = 3, Date = DateTime.Today.AddDays(3), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(14, 0, 0), MaxPatients = 12, price = 220 }
            );

            // Seed Patients 
            modelBuilder.Entity<Patient>().HasData(
                new Patient { ID = 1, Name = "Alice Johnson", Age = 30, Address = "789 Oak St", PhoneNumber = "555-2345", Email = "alice@example.com", Gender = Gender.Female, medicalhistory = "No significant medical history" },
                new Patient { ID = 2, Name = "Bob Williams", Age = 45, Address = "321 Pine St", PhoneNumber = "555-6789", Email = "bob@example.com", Gender = Gender.Male, medicalhistory = "Hypertension" }
            );

            // Seed Appointments 
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { ID = 1, AppointmentDate = DateTime.Today.AddDays(1), AppointmentTime = new TimeSpan(9, 30, 0), ReasonForVisit = "Routine Checkup", Status = AppointmentStatus.Scheduled, PatientID = 1, StaffID = 1 },
                new Appointment { ID = 2, AppointmentDate = DateTime.Today.AddDays(2), AppointmentTime = new TimeSpan(14, 0, 0), ReasonForVisit = "Skin Rash", Status = AppointmentStatus.Scheduled, PatientID = 2, StaffID = 2 }
            );
        }
    }

}
