using CarBook.Domain.Enums;

namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarByIdDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; } = null!;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public string BigImageUrl { get; set; } = null!;
    }
}
