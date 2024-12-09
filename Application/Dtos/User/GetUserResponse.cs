﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User
{
    public class GetUserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public AccountStatusEnum AccountStatus { get; set; }
        public UserRolesEnum UserRole { get; set; }
        public string Address { get; set; }
        public string gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
