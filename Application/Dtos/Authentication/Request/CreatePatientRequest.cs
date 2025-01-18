namespace Application.Dtos.Authentication.Request
{
    public class CreatePatientRequest : BaseCreateUserRequest
    {
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string? BloodType { get; set; }
        public string? UserInsuranceProviderId { get; set; }
    }
}
