﻿using Domain.Entities.ClinicEntity;
using Domain.Entities.User;
using Microsoft.AspNetCore.Http;


namespace Application.Dtos.Clinic
{
    public class ClinicRequest
    {
        public string Name { get; set; }
        public int CountrryId { get; set; }
        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<IFormFile> Gallery { get; set; }

    }
}
