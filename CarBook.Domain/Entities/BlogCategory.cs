namespace CarBook.Domain.Entities
{
    public class BlogCategory : BaseEntity
    {
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
