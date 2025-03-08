namespace CarBook.Domain.Entities
{
    public class FooterAddress : BaseEntity
    {
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
