using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AppointmentName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string DoctorName { get; set; }
        public int Price { get; set; }
        public string? UserId { get; set; } = null;
    }
}
