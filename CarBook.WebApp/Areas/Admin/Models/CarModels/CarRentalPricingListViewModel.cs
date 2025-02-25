using CarBook.Domain.Entities;
using CarBook.WebApp.Areas.Admin.Models.RentalPricingModels;

namespace CarBook.WebApp.Areas.Admin.Models.CarModels
{
    public class CarRentalPricingListViewModel
    {
        public int CarId { get; set; }
        public CarViewModel Car { get; set; } = null!;
        public IEnumerable<RentalPricingViewModel> RentalPricings { get; set; } = null!;
    }
}
