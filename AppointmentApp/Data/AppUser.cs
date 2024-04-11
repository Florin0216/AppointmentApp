using AppointmentApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AppointmentApp.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
