using CarBook.Domain.Entities;

namespace CarBook.Application.Dtos.BlogTagCloudDtos
{
    public class GetBlogTagsByBlogIdDto
    {
        public int Id { get; set; }
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }
        public int BlogId { get; set; }
    }
}
