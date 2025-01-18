namespace Domain.Entities.User
{
    public class Secretary : ApplicationUser
    {
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateOnly HireDate { get; set; }
    }
}