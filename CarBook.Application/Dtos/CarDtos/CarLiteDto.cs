using CarBook.Domain.Enums;

namespace CarBook.Application.Dtos.CarDtos
{
    public class CarLiteDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
    }
}
