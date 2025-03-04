namespace CarBook.Application.Features.CarFeatures.Results
{
    public class GetCarDescriptionsByCarIdQueryResult
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
