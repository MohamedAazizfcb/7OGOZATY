using Domain.Entities.Lookups;
using Domain.Entities.User;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Authentication
{
    public abstract class BaseCreateUserRequest
    {
        public string Username{ get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
    }
}
