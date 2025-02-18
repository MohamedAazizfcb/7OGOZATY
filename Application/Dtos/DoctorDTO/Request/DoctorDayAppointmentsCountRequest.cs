namespace Application.Dtos.DoctorDTO.Response
{
    public class DoctorDayAppointmentsCountRequest
    {
        public int DocId { get; set; }
        public DateOnly Date {  get; set; }
    }
}
