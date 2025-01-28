namespace Application.Dtos.AppointmentDTO.Request
{
    public class SearchAppointmentsRequest
    {
        public int? AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctortFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public int? PatientID { get; set; }
        public string? PatientFirstName { get; set; }
        public string? PatientLastName { get; set; }
        public string? PatientMobileNumber { get; set; }
        public DateOnly? AppointmentDate { get; set; }
        public int? AppointmentStatusId { get; set; }
        public int? ClinicId { get; set; }
    }
}
