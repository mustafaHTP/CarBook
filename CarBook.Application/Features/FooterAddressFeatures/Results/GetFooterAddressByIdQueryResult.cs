namespace CarBook.Application.Features.FooterAddressFeatures.Results
{
    public class GetFooterAddressByIdQueryResult
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
