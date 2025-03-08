using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarFeatures.Results
{
    public class GetCarRentalPricingsByIdQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int PricingPlanId { get; set; }
        public RentalPeriod PricingPlan { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
