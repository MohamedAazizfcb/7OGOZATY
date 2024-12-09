using Domain.Entities.User;

namespace Domain.Entities.InsuranceProviderEntities
{
    public class UserInsuranceProvider
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string ContactInfo { get; set; } 
        public string Notes { get; set; }

        public IEnumerable<Patient>? Patients { get; set; }
    }
}
