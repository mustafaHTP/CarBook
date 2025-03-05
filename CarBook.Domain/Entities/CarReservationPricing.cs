namespace CarBook.Domain.Entities
{
    public class CarReservationPricing : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int RentalPeriodId { get; set; }
        public RentalPeriod RentalPeriod { get; set; }
        public decimal Price { get; set; }
    }
}
