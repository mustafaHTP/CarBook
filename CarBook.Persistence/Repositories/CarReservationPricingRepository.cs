using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class CarReservationPricingRepository : Repository<CarReservationPricing>, ICarReservationPricingRepository
    {
        public CarReservationPricingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IEnumerable<CarReservationPricing> GetAll(IEnumerable<string>? rentalPeriods)
        {
            var carReservationPricings = _context.CarReservationPricings.AsQueryable();
            if(rentalPeriods is not null)
            {
                // Get pricing plan ids for the given rental periods
                var pricingPlanIds = _context
                    .PricingPlans
                    .Where(pp => rentalPeriods.Contains(pp.Name.ToLower()))
                    .Select(pp => pp.Id)
                    .AsQueryable();

                // Get car reservation pricings for the given pricing plan ids
                carReservationPricings = _context.CarReservationPricings
                    .Where(crp => pricingPlanIds.Contains(crp.PricingPlanId))
                    .AsQueryable();
            }

            //Include car, model, brand and pricing plan
            return carReservationPricings
                .Include(crp => crp.Car)
                .ThenInclude(c => c.Model)
                .ThenInclude(m => m.Brand)
                .Include(crp => crp.PricingPlan)
                .ToList();
        }

        public List<CarReservationPricing> GetAllWithCarAndDayPricePlan()
        {
            return _context.CarReservationPricings
                .Include(crp => crp.PricingPlan)
                .Include(crp => crp.Car)
                .ThenInclude(c => c.Model)
                .ThenInclude(m => m.Brand)
                .Where(crp => crp.PricingPlanId == 2)
                .ToList();
        }

        /// <summary>
        /// Gets all CarReservationPricing with Car (with Model and Brand) and PricePlan
        /// </summary>
        /// <returns></returns>
        public List<CarReservationPricing> GetAllWithCarAndPricePlan()
        {
            return _context.CarReservationPricings
                .Include(crp => crp.PricingPlan)
                .Include(crp => crp.Car)
                .ThenInclude(c => c.Model)
                .ThenInclude(m => m.Brand)
                .ToList();
        }
    }
}
