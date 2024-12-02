using Domain.Entities.User;

namespace Domain.Entities.InsuranceProviderEntities
{
    public class UserInsuranceProvider
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty; // Provider's name
        public string ContactInfo { get; set; } = string.Empty; // Contact details
        public string Notes { get; set; } = string.Empty; // Additional information

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
