using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectAutoCore.Models

{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CarId { get; set; }
        public int ServiceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Car Car { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }

}
