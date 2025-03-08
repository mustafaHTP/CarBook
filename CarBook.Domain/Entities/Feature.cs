namespace CarBook.Domain.Entities
{
    public class Feature : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<CarFeature> CarFeatures { get; set; } = [];
    }
}
