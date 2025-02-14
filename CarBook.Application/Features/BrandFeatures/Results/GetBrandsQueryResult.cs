using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BrandFeatures.Results
{
    public class GetBrandsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
    }
}
