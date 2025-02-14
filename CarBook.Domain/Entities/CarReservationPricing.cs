namespace CarBook.Domain.Entities
{
    public class CarReservationPricing : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingPlanId { get; set; }
        public PricingPlan PricingPlan { get; set; }
        public decimal Price { get; set; }
    }
}
