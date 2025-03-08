namespace CarBook.Domain.Entities
{
    public class BlogAuthor : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public List<Blog> Blogs { get; set; } = [];
    }
}
