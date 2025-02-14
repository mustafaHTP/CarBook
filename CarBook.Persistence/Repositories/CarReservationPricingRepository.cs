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
