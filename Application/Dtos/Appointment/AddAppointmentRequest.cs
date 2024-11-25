using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Appointment
{
    public class AddAppointmentRequest
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string SlotId { get; set; }
    }
}
