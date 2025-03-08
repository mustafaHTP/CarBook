namespace CarBook.Domain.Entities
{
    public class CarReservationPricing : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int RentalPeriodId { get; set; }
        public RentalPeriod RentalPeriod { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
