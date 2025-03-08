namespace CarBook.Domain.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
