using CarBook.Domain.Enums;

namespace CarBook.WebApp.Areas.Admin.Models.CarModels
{
    public class UpdateCarViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
    }
}
