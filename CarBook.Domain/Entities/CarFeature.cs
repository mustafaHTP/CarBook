namespace CarBook.Domain.Entities
{
    public class CarFeature : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } = null!;
        public bool Available { get; set; }
    }
}
