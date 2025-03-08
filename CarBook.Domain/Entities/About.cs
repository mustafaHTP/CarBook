namespace CarBook.Domain.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
