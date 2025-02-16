using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BlogFeatures.Results
{
    public class GetBlogsQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public BlogAuthor? BlogAuthor { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory? BlogCategory { get; set; }
    }
}
