namespace CarBook.Domain.Entities
{
    public class BlogTagCloud : BaseEntity
    {
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; } = null!;
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }
}
