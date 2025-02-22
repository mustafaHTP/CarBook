namespace CarBook.WebApp.Models
{
    public class PricingPlanViewModel
    {
        public int PricingPlanId { get; set; }
        public string PricingPlanName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
