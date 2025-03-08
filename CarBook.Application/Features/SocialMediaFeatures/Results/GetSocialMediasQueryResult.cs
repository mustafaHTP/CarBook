namespace CarBook.Application.Features.SocialMediaFeatures.Results
{
    public class GetSocialMediasQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
