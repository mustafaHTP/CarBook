namespace CarBook.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public BlogAuthor BlogAuthor { get; set; } = null!;
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; } = null!;
        public List<BlogTagCloud> BlogTagClouds { get; set; } = [];
        public List<BlogComment> BlogComments { get; set; } = [];
    }
}
