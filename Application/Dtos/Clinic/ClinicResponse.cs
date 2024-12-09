using Domain.Entities.ClinicEntity;
using Domain.Entities.User;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;

namespace Application.Dtos.Clinic
{
    public class ClinicResponse
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Country Country { get; set; }
        public Governorate Governorate { get; set; }
        public District District { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<ClinicGallery> Gallery { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
