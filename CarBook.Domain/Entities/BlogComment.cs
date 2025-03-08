namespace CarBook.Domain.Entities
{
    public class BlogComment : BaseEntity
    {
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }
}
