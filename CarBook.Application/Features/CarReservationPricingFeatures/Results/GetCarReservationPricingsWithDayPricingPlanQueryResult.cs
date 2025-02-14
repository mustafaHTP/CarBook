using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Results
{
    public class GetCarReservationPricingsWithDayPricingPlanQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingPlanId { get; set; }
        public PricingPlan PricingPlan { get; set; }
        public decimal Price { get; set; }
    }
}
