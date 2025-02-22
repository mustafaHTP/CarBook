using CarBook.Domain.Enums;

namespace CarBook.WebApp.Models
{
    public class GetCarReservationListViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public string BigImageUrl { get; set; } = string.Empty;
        public IList<PricingPlanViewModel> PricingPlans { get; set; } = [];
    }
}
