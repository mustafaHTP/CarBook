namespace CarBook.Domain.Entities
{
    public class RentalPeriod : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<CarReservationPricing>? CarReservationPricings { get; set; }
    }
}
