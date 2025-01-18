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

        public virtual IEnumerable<DoctorCertificate>? DoctorCertificates { get; set; }

        public virtual IEnumerable<TimeSlot>? TimeSlots { get; set; }

        public virtual IEnumerable<Appointment>? Appointments { get; set; }

        public virtual IEnumerable<Feedback>? FeedbackRecievedByMe { get; set; }

        public virtual IEnumerable<DoctorServicePivot>? DoctorServicePivots { get; set; }

    }
}
