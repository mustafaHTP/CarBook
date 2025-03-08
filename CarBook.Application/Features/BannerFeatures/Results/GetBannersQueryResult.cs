namespace CarBook.Application.Features.BannerFeatures.Results
{
    public class GetBannersQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoDescription { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
    }
}
