namespace CarBook.Domain.Entities
{
    public class BlogComment : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
