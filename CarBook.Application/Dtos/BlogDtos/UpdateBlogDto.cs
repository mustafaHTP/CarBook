namespace CarBook.Application.Dtos.BlogDtos
{
    public class UpdateBlogDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
