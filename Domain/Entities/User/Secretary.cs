namespace Domain.Entities.User
{
    public class Secretary : ApplicationUser
    {
        public int? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
    }
}