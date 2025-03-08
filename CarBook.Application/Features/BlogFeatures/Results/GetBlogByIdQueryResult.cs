using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BlogFeatures.Results
{
    public class GetBlogByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public BlogAuthor? BlogAuthor { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory? BlogCategory { get; set; }
    }
}
