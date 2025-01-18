using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Domain.Entities.ClinicEntity
{
    public class Clinic
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Relationships
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int GovernorateId { get; set; }
        public virtual Governorate Governorate { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<ClinicGallery>? ClinicGallery { get; set; }

        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
