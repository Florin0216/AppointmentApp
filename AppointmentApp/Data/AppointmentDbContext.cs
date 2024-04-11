using AppointmentApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApp.Data
{
    public class AppointmentDbContext : IdentityDbContext <AppUser>
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) 
        {       
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
