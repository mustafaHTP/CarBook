namespace CarBook.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Model> Models { get; set; } = [];
    }
}
