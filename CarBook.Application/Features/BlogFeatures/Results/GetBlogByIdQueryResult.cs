namespace CarBook.Application.Features.BlogFeatures.Results
{
    public class GetBlogByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
