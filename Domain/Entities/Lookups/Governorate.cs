namespace Domain.Entities.Lookups
{
    public class Governorate : Lookup
    {
        public int CountryID { get; set; }
        public Country Country { get; set; } = null!;

        public IEnumerable<District>? Districts { get; set; }
    }
}
