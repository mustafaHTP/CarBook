namespace CarBook.Application.Dtos.BlogCommentDtos
{
    public class GetBlogCommentsByBlogIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }
    }
}
