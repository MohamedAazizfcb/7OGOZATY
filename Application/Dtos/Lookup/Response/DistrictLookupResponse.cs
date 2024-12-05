using Domain.Entities.Lookups;

namespace Application.Dtos.Lookup.Response
{
    public class CreateUpdateDistrictResponse : CreateUpdateLookupResponse
    {
        public int GovernorateID { get; set; }
        public Governorate Governorate { get; set; } = null!;
    }
}
