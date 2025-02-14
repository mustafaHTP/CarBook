namespace CarBook.Application.Features.AboutFeatures.Results
{
    public class GetAboutByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
