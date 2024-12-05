using Domain.Entities.AppointmentEntities;
using Domain.Entities.ClinicEntity;
using Domain.Entities.DoctorCertificateEntity;
using Domain.Entities.FeedbackEntity;
using Domain.Entities.Lookups;
using Domain.Entities.SpecializationServicesEntity;
using Domain.Entities.TimeSlotEntity;

namespace Domain.Entities.User
{
    public class Doctor : ApplicationUser
    {
        public string Brief { get; set; }

        public int? ClinicId { get; set; }
        public virtual Clinic? Clinic { get; set; }

        public int? SpecializationId { get; set; }
        public virtual Specialization? Specialization { get; set; }

        public int? CertificateId { get; set; }
        public virtual ICollection<DoctorCertificate> DoctorCertificates { get; set; } = new List<DoctorCertificate>();

        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual ICollection<Feedback> FeedbackRecievedByMe { get; set; } = new List<Feedback>();

        public virtual ICollection<DoctorServicePivot> DoctorServicePivots { get; set; } = new List<DoctorServicePivot>();

    }
}
