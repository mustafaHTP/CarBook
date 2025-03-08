namespace CarBook.Domain.Entities
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoDescription { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
    }
}
