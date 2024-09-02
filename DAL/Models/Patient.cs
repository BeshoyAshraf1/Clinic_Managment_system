using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string medicalhistory  { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }


}
