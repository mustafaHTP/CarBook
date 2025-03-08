namespace CarBook.WebApp.Areas.Admin.Models.FooterAddressModels
{
    public class UpdateFooterAddressViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
