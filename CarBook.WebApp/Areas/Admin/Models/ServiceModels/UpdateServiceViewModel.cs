namespace CarBook.WebApp.Areas.Admin.Models.ServiceModels
{
    public class UpdateServiceViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }
}
