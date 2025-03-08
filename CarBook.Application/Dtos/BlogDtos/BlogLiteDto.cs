namespace CarBook.Application.Dtos.BlogDtos
{
    public class BlogLiteDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
