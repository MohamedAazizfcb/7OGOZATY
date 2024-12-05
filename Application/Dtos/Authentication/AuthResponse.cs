using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Application.Dtos.Authentication
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Governorate? Governorate { get; set; }
        public virtual District? District { get; set; }
        public virtual AccountStatus? AccountStatus { get; set; }
        public virtual ApplicationRole? ApplicationRole { get; set; }
    }
}
