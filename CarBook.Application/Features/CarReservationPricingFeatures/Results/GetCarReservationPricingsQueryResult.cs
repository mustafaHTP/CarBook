using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Results
{
    public class GetCarReservationPricingsQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingPlanId { get; set; }
        public PricingPlan PricingPlan { get; set; }
        public decimal Price { get; set; }
    }
}
