namespace Application.Dtos.Lookup.Request
{
    public class CreateUpdateDistrictResponse : CreateUpdateLookupResponse
    {
        public int GovernorateID { get; set; }
        public Governorate Governorate { get; set; } = null!;
    }
}
