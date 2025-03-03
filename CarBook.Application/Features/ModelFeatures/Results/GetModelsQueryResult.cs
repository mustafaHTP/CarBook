using CarBook.Domain.Entities;

namespace CarBook.Application.Features.ModelFeatures.Results
{
    public class GetModelsQueryResult
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<Car>? Cars { get; set; }
    }
}
