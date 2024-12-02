using Domain.Entities.Lookups;

namespace Application.Dtos.Lookup.Response
{
    public class CreateUpdateCountryResponse : CreateUpdateLookupResponse
    {
        public ICollection<Governorate> Governorates { get; set; } = new List<Governorate>();
    }
}
