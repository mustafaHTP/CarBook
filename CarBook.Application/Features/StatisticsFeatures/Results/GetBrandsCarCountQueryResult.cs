namespace CarBook.Application.Features.StatisticsFeatures.Results
{
    public class GetBrandsCarCountQueryResult
    {
        public string BrandName { get; set; } = null!;
        public int CarCount { get; set; }
    }
}
