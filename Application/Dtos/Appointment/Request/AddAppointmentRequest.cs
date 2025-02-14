namespace Application.Dtos.AppointmentDTO.Request
{
    public class CreateAppointmentRequest
    {
        public string Notes { get; set; }

        public int TimeSlotId { get; set; }

        public int? ClinicId { get; set; }

        public int DoctorId { get; set; }

        public int PatientID { get; set; }
    }
}
