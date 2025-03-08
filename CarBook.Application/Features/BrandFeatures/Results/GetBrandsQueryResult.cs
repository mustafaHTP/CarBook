using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BrandFeatures.Results
{
    public class GetBrandsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Model>? Models { get; set; }
    }
}
