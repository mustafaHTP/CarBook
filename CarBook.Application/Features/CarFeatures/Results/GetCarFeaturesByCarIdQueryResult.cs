using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarFeatures.Results
{
    public class GetCarFeaturesByCarIdQueryResult
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public bool IsAvailable { get; set; }
    }
}
