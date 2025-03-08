namespace CarBook.Application.Dtos.BlogDtos
{
    public class GetBlogsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public string? BlogAuthorName { get; set; }
        public string? BlogAuthorDescription { get; set; }
        public string? BlogAuthorImageUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public string? BlogCategoryName { get; set; }
    }
}
