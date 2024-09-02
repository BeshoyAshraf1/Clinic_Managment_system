using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

        public class DoctorSchedule
        {
            public int Id { get; set; }

            public int StaffId { get; set; }
            public virtual Staff Staff { get; set; }

            public DateTime Date { get; set; }  // The date of the schedule

 
            public TimeSpan StartTime { get; set; }  // Start time of the doctor's availability

       
            public TimeSpan EndTime { get; set; }  // End time of the doctor's availability

            
            public int MaxPatients { get; set; }  // Maximum number of patients the doctor will see during this time slot

        public double price { get; set; } 
        }



    

}
