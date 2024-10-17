using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using GradPro.Data;

namespace GradPro.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Patient).Include(a => a.Staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5

        public async Task <IActionResult> gedo(int ?id)
        {
            
            var doc =await _context.Appointments.Where(x => x.StaffID == id).ToListAsync();

            return View(doc);
            //ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> gedo(int id, IEnumerable<Appointment> app)


        {
            //if (id != app.ID)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                Appointment asp = new Appointment();

                //try
                foreach (var appointment in app)
                {
                    // Find the existing appointment in the database
                    var existingAppointment = await _context.Appointments.FindAsync(appointment.ID);
                    if (existingAppointment != null)
                    {
                        // Update only the Status property (or others if needed)
                        existingAppointment.Status = appointment.Status;
                        existingAppointment.ReasonForVisit = appointment.ReasonForVisit;
                        // You can also update other fields if necessary
                    }

                    //}
                    //catch (DbUpdateConcurrencyException)
                    //{
                    //    if (!AppointmentExists(app.ID))
                    //    {
                    //        return NotFound();
                    //    }
                    //    else
                    //    {
                    //        throw;
                    //    }
                    await _context.SaveChangesAsync();

  //ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appointment.Status);
                }              
                return RedirectToAction(nameof(Index));


                //ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appo.Status);
                //ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address", app.PatientID);
                //ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department", app.StaffID);
            }
            return View(app);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department");
            ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status");

            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AppointmentDate,AppointmentTime,ReasonForVisit,Status,PatientID,StaffID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address", appointment.PatientID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department", appointment.StaffID);
            ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appointment.Status);

            return View(appointment);
        }

        public async Task<IActionResult> EditStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            //ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address", appointment.PatientID);
            //ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department", appointment.StaffID);
            ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appointment.Status);

            return View(appointment);
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatus(int id, [Bind("ID,AppointmentDate,AppointmentTime,ReasonForVisit,Status,PatientID,StaffID")] Appointment appointment)
        {
            if (id != appointment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address", appointment.PatientID);
            //ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department", appointment.StaffID);
            ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appointment.Status);

            return View(appointment);
        }


        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address", appointment.PatientID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department", appointment.StaffID);
            ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appointment.Status);

            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AppointmentDate,AppointmentTime,ReasonForVisit,Status,PatientID,StaffID")] Appointment appointment)
        {
            if (id != appointment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "Address", appointment.PatientID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "ID", "Department", appointment.StaffID);
            ViewData["Status"] = new SelectList(_context.Appointments, "ID", "Status", appointment.Status);

            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
    }
}
