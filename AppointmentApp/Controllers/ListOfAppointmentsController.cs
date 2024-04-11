using AppointmentApp.Data;
using AppointmentApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppointmentApp.Controllers
{
    public class ListOfAppointmentsController : Controller
    {
        private readonly AppointmentDbContext _db;

        public ListOfAppointmentsController(AppointmentDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAppointments = _db.Appointments.Where(a => a.UserId == userId).ToList();

            return View(userAppointments);
        }
        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Create
        [HttpPost]
        public IActionResult Create(Appointment appointment) 
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            appointment.UserId = userId;
            if (ModelState.IsValid)
            {
                if (appointment.Date < DateTime.Now)
                {
                    TempData["WrongDate"] = "The date you have entered is wrong!";
                    return RedirectToAction("Create");
                }
                else
                {
                    _db.Appointments.Add(appointment);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //When model is invalid
                return RedirectToAction("Create");
            }
        }
        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _db.Appointments.FirstOrDefault(a => a.Id == id);
            return View(data);
        }
        //Edit
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            var data = _db.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (data != null)
            {
                data.AppointmentName = appointment.AppointmentName;
                data.Date = appointment.Date;
                data.DoctorName = appointment.DoctorName;
                data.Price = appointment.Price;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Delete
        public IActionResult Delete(int id)
        {
            var data = _db.Appointments.FirstOrDefault(a => a.Id == id);
            if (data != null)
            {
                _db.Appointments.Remove(data);
                _db.SaveChanges();
            }
           return RedirectToAction("Index");
        }
    }
}
