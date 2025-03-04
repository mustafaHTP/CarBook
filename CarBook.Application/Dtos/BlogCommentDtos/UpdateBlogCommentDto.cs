namespace CarBook.Application.Dtos.BlogCommentDtos
{
    public class UpdateBlogCommentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
