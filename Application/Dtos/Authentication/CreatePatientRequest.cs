namespace Application.Dtos.Authentication
{
    public class CreatePatientRequest : BaseCreateUserRequest
    {
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string? BloodType { get; set; }
    }
}
