using Domain.Entities.AppointmentEntities;
using Domain.Entities.User;

namespace Domain.Entities.ClinicEntity
{
    public class Clinic
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public ICollection<ClinicGallery> Gallery { get; set; } = new List<ClinicGallery>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
