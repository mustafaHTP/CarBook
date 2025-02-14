namespace CarBook.Domain.Entities
{
    public class BlogAuthor : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
