using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AppointmentDTO
{
    public class GetAppointmentResponse
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        //public ScheduleDetail Slot { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
