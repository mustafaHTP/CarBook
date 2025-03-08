namespace CarBook.Domain.Entities
{
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
