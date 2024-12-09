namespace Application.Dtos.Authentication
{
    public class CreateDoctorRequest : BaseCreateUserRequest
    {
        public string Brief { get; set; }
        public int ClinicId { get; set; }
        public int SpecializationId { get; set; }
    }
}
