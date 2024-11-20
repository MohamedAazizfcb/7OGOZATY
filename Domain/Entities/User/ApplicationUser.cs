using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public UserRoles UserRole { get; set; }
        public string Address { get; set; }
        public int gender { get; set; }
        public List<ScheduleDetail> Schedule { get; set; } = new List<ScheduleDetail>();
    }
}
