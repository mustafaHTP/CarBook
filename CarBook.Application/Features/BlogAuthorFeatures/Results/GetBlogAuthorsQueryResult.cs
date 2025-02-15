using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BlogAuthorFeatures.Results
{
    public class GetBlogAuthorsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
