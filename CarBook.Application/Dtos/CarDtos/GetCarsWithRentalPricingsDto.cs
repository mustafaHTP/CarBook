using CarBook.Application.Dtos.PricingPlanDtos;

namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarsWithRentalPricingsDto
    {
        public CarLiteDto Car { get; set; } = null!;
        public IEnumerable<PricingPlanWithPriceDto>? RentalPricings { get; set; }
    }
}
