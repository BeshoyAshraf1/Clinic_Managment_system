using DAL.Models;
using GradPro.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradPro.Controllers
{
    public class PatientController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(Guid? Id)
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            id = 2;

            var appointment = _context.Appointments
                .Where(x => x.PatientID == id)
                .Include(x => x.Patient)
                .ToList();
            return View(appointment);
        }

        public IActionResult Appoitment()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetDoctorsBySpecialty(Specialty specialty)
        {
            var doctors = _context.Staffs
                .Where(s => s.Specialty == specialty && s.Position == StaffPosition.Doctor)
                .Select(s => new { s.ID, s.Name })
                .ToList();

            return Json(doctors);
        }





        [HttpGet]
        public JsonResult GetAvailableDates(int doctorId)
        {
            var availableDates = _context.DoctorSchedules
                .Where(s => s.StaffId == doctorId)
                .Select(s => new
                {
                    s.Date,
                    s.StartTime,
                    s.EndTime,
                    s.price
                })
                .ToList();

            return Json(availableDates);
        }


        [HttpGet]
        public JsonResult GetAvailableTimes(int doctorId, DateTime date)
        {
            var availableTimes = _context.DoctorSchedules
                .Where(s => s.StaffId == doctorId && s.Date == date)
                .Select(s => new
                {
                    s.StartTime,
                    s.EndTime
                })
                .ToList();

            return Json(availableTimes);
        }

        [HttpGet]
        public JsonResult GetPrice(int doctorId, DateTime date, TimeSpan time)
        {
            var schedule = _context.DoctorSchedules
                .FirstOrDefault(s => s.StaffId == doctorId && s.Date == date && s.StartTime <= time && s.EndTime >= time);

            var price = schedule != null ? schedule.price.ToString("C") : "N/A";

            return Json(new { price });
        }



        [HttpPost]
        public IActionResult AddAppointment(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    AppointmentDate = model.AppointmentDate,
                    AppointmentTime = model.AppointmentTime,
                    ReasonForVisit = model.Message,
                    Status = AppointmentStatus.Scheduled,
                    PatientID =2,
                    //model.PatientId,
                    StaffID = model.DoctorId
                };

                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Appointment added successfully!";


                return RedirectToAction("Appoitment"); 
            }

            return View("Appointment", model); 
        }

        public class AppointmentViewModel
        {
            public int DoctorId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public TimeSpan AppointmentTime { get; set; }
            public string Message { get; set; }
            public int PatientId { get; set; }
        }


    }
}
