using CarBook.Application.Dtos.BlogDtos;

namespace CarBook.Application.Dtos.BlogAuthorDtos
{
    public class GetBlogAuthorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public List<BlogLiteDto>? Blogs { get; set; }
    }
}
