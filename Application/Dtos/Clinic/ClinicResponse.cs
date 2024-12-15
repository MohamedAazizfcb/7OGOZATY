﻿using Domain.Entities.ClinicEntity;
using Domain.Entities.User;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;

namespace Application.Dtos.Clinic
{
    public class ClinicResponse
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Address_En { get; set; }
        public string Address_Ar { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<string> ClinicGallery { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
