using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectAutoCore.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ClientId is required.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        public string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2024, ErrorMessage = "Year must be between 1900 and 2024.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "VIN is required.")]
        public string VIN { get; set; } = string.Empty;

        public Client? Client { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
