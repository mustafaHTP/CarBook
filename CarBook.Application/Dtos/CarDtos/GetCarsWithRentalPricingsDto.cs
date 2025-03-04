using CarBook.Application.Dtos.PricingPlanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarsWithRentalPricingsDto
    {
        public CarLiteDto Car { get; set; } = null!;
        public IEnumerable<PricingPlanWithPriceDto>? RentalPricings { get; set; }
    }
}
