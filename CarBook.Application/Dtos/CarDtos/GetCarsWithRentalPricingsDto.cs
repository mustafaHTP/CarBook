
using CarBook.Application.Dtos.RentalPeriodDtos;

namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarsWithRentalPricingsDto
    {
        public CarLiteDto Car { get; set; } = null!;
        public IEnumerable<RentalPeriodWithPriceDto>? RentalPricings { get; set; }
    }
}
