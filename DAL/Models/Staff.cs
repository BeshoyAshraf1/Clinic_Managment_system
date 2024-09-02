
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public StaffPosition Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public double? salary { get; set; }
        public Specialty? Specialty { get; set; }
        public int ClinicID { get; set; }

        public Clinic Clinic { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<DoctorSchedule>? Schedules { get; set; }

    }
    public enum StaffPosition
    {
        Doctor,
        Nurse,
        Receptionist,
        Administrator,
        Other
    }

    public enum Specialty
    {
        Cardiology,
        Dermatology,
        Endocrinology,
        Family_Medicine,
        Internal_Medicine,
        Neurology,
        Obstetrics_and_Gynecology,
        Orthopedics,
        Pediatrics,
        Surgery
    }

}
