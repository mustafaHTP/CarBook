namespace CarBook.Application.Dtos.BlogAuthorDtos
{
    public class GetBlogAuthorByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
