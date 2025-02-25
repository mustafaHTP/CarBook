namespace CarBook.WebApp.Areas.Admin.Models.RentalPricingModels
{
    public class RentalPricingViewModel
    {
        public int PricingPlanId { get; set; }
        public string PricingPlanName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
