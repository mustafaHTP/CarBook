namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarFeaturesByCarIdDto
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
