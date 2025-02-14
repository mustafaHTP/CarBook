namespace CarBook.Domain.Entities
{
    public class Model : BaseEntity
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
