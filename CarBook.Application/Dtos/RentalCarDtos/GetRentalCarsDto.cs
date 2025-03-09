using CarBook.Application.Dtos.CarDtos;
using CarBook.Domain.Entities;

namespace CarBook.Application.Dtos.RentalCarDtos
{
    public class GetRentalCarsDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;
        public int CarId { get; set; }
        public CarWithReservationPricingsDto Car { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
