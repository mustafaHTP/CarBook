using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarRentalPricingsByCarIdDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PricingPlanId { get; set; }
        public string PricingPlanName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
