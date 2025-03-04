using CarBook.Domain.Enums;

namespace CarBook.Application.Dtos.CarReservationPricingDtos
{
    public class GetCarReservationPricingsDto
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
        public int PricingPlanId { get; set; }
        public string PricingPlanName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
