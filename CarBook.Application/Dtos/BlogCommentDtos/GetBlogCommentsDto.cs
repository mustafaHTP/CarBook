namespace CarBook.Application.Dtos.BlogCommentDtos
{
    public class GetBlogCommentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
