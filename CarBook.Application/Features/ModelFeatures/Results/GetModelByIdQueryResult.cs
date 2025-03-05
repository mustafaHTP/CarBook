using CarBook.Domain.Entities;

namespace CarBook.Application.Features.ModelFeatures.Results
{
    public class GetModelByIdQueryResult
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
