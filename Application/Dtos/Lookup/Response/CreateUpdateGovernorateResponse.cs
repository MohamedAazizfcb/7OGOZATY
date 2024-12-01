namespace Domain.Entities.Lookups
{
    public class CreateUpdateGovernorateResponse : CreateUpdateLookupResponse
    {
        public int CountryID { get; set; }
        public Country Country { get; set; } = null!;

        public ICollection<District> Districts { get; set; } = new List<District>();
    }
}
