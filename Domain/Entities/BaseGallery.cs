namespace Domain.Entities
{
    public abstract class BaseGallery
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? ImageDescription { get; set; } = string.Empty;
    }
}
