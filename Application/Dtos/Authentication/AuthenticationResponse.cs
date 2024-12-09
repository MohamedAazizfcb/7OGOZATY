using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Application.Dtos.Authentication
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime LastLogin { get; set; }
        public Gender? Gender { get; set; }
        public Country? Country { get; set; }
        public Governorate? Governorate { get; set; }
        public District? District { get; set; }
        public AccountStatus? AccountStatus { get; set; }
        public ApplicationRole? ApplicationRole { get; set; }
    }
}
