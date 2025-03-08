namespace CarBook.WebApp.Areas.Admin.Models.BlogAuthorModels
{
    public class UpdateBlogAuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
