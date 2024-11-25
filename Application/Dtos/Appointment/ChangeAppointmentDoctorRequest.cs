using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Appointment
{
    public class ChangeAppointmentDoctorRequest
    {
        public string DoctorId { get; set; }
        public string SlotId { get; set; }
    }
}
