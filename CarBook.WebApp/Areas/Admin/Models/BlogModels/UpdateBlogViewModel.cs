namespace CarBook.WebApp.Areas.Admin.Models.BlogModels
{
    public class UpdateBlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
