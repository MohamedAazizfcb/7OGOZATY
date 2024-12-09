using Domain.Entities.AppointmentEntities;
using Domain.Entities.FeedbackEntity;
using Domain.Entities.InsuranceProviderEntities;
using Domain.Entities.MedicalRecordEntities;

namespace Domain.Entities.User
{
    public class Patient : ApplicationUser
    {
        public int MedicalRecordId { get; set; } // Foreign Key to MedicalRecord
        public virtual MedicalRecord MedicalRecord { get; set; } = null!;

        public int? UserInsuranceProviderId { get; set; } // Foreign Key to InsuranceProvider
        public virtual UserInsuranceProvider? InsuranceProvider { get; set; } = null!;

        public string? InsurancePolicyNumber { get; set; } = string.Empty;


        public string EmergencyContactName { get; set; } = string.Empty; // Emergency contact name
        public string EmergencyContactPhone { get; set; } = string.Empty; // Emergency contact phone
        public string BloodType { get; set; } = string.Empty; // Patient's blood type
        public string Notes { get; set; } = string.Empty; // Additional notes

        public virtual IEnumerable<Appointment>? Appointments { get; set; }

        public virtual IEnumerable<Feedback>? FeedbackRecievedByMe { get; set; }


    }
}