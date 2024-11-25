using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
