namespace CarBook.Application.Features.FooterAddressFeatures.Results
{
    public class GetFooterAddressesQueryResult
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
