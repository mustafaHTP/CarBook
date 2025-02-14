namespace CarBook.Application.Features.ServiceFeatures.Results
{
    public class GetServiceByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
