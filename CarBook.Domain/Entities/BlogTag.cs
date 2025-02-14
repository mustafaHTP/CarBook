namespace CarBook.Domain.Entities
{
    public class BlogTag : BaseEntity
    {
        public string Name { get; set; }
        public List<BlogTagCloud> BlogTagClouds { get; set; }
    }
}
