namespace CarBook.Domain.Entities
{
    public class PricingPlan : BaseEntity
    {
        public string Name { get; set; }
        public List<CarReservationPricing> CarReservationPricings { get; set; }
    }
}
