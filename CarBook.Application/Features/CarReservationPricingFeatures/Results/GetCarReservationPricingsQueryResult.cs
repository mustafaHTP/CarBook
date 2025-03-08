using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Results
{
    public class GetCarReservationPricingsQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int RentalPeriodId { get; set; }
        public RentalPeriod RentalPeriod { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
