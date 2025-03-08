namespace CarBook.WebApp.Areas.Admin.Models.BannerModels
{
    public class CreateBannerViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoDescription { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
    }
}
