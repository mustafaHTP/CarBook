namespace CarBook.Domain.Entities
{
    public class Model : BaseEntity
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<Car> Cars { get; set; } = [];
    }
}
