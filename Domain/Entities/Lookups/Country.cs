namespace Domain.Entities.Lookups
{
    public class Country : Lookup
    {
        public IEnumerable<Governorate>? Governorates { get; set; }
    }
}
