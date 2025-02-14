namespace CarBook.Application.Features.BlogCommentFeatures.Results
{
    public class GetBlogCommentByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
