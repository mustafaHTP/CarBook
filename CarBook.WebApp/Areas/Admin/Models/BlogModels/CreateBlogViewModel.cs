namespace CarBook.WebApp.Areas.Admin.Models.BlogModels
{
    public class CreateBlogViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
