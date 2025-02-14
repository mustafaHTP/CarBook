using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Results
{
    public class GetBlogTagCloudByBlogIdWithBlogTagQueryResult
    {
        public int Id { get; set; }
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }
        public int BlogId { get; set; }
    }
}
