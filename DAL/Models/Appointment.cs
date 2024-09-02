using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string ReasonForVisit { get; set; }
        public AppointmentStatus Status { get; set; }

        
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int StaffID { get; set; }        
        public Staff Staff { get; set; }
    }

    public enum AppointmentStatus
    {
        Scheduled,   
        Completed,  
        Canceled,   
        Missed,    
        Rescheduled 
    }

}
