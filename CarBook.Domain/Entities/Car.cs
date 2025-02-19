using CarBook.Domain.Enums;

namespace CarBook.Domain.Entities
{
    public class Car : BaseEntity
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public RentalCar? RentalCar { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarReservationPricing> CarReservationPricings { get; set; }
    }
}
