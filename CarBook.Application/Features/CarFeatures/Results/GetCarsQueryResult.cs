using CarBook.Domain.Entities;
using CarBook.Domain.Enums;

namespace CarBook.Application.Features.CarFeatures.Results
{
    public class GetCarsQueryResult
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
    }
}
