namespace CarBook.Application.Features.BlogAuthorFeatures.Results
{
    public class GetBlogAuthorByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
