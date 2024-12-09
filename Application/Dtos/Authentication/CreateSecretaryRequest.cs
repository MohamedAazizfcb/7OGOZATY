namespace Application.Dtos.Authentication
{
    public class CreateSecretaryRequest : BaseCreateUserRequest
    {
        public int DoctorId { get; set; }
        public DateTime HireDate { get; set; }
    }
}
