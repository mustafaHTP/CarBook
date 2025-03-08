namespace CarBook.Domain.Entities
{
    public class BlogCategory : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Blog> Blogs { get; set; } = [];
    }
}
