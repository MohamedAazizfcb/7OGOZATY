namespace Domain.Entities.ClinicEntity
{
    public class ClinicGallery : BaseGallery
    {
        public int ClinicId { get; set; } // Foreign Key
        public Clinic Clinic { get; set; }
    }
}
