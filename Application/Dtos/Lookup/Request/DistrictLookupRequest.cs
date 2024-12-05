namespace Application.Dtos.Lookup.Request
{
    public class CreateUpdateDistrictRequest : CreateUpdateLookupRequest
    {
        public int GovernorateID { get; set; }
    }
}
