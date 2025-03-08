namespace CarBook.WebApp.Areas.Admin.Models.SocialMediaModels
{
    public class UpdateSocialMediaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
