using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Car> GetAllCarsWithModel()
        {
            return [.. _context.Cars.Include(c => c.Model)];
        }

        public List<Car> GetAllCarsWithBrand()
        {
            return [.. _context.Cars.Include(c => c.Model).ThenInclude(m => m.Brand)];
        }

        public List<Car> GetLast5CarsWithBrand()
        {
            return [.. _context.Cars.Include(c => c.Model).ThenInclude(m => m.Brand).OrderByDescending(c => c.Id)];
        }

        public List<Car> GetCarsWithReservationPricings()
        {
            return [.. _context.Cars.Include(c => c.Model).ThenInclude(m => m.Brand).Include(c => c.CarReservationPricings).ThenInclude(cr => cr.PricingPlan)];
        }

        public Car? GetById(int id)
        {
            var cars = _context.Cars
                .Include(c => c.Model)
                .ThenInclude(m => m.Brand);

            return cars.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<CarFeature> GetCarFeaturesByCarId(int carId)
        {
            return _context.CarFeatures.Where(cf => cf.CarId == carId).Include(cf => cf.Feature);
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars
                .Include(c => c.Model)
                .ThenInclude(m => m.Brand);
        }

        public IEnumerable<CarDescription> GetCarDescriptionsByCarId(int carId)
        {
            return _context.CarDescriptions.Where(cd => cd.CarId == carId);
        }

        public IEnumerable<CarReservationPricing> GetCarRentalPricingsByCarId(int carId)
        {
            return _context.CarReservationPricings.Where(cr => cr.CarId == carId).Include(cr => cr.PricingPlan);
        }

        public IEnumerable<Car> GetAllWithRentalPricings()
        {
            var rentalPricings = _context.Cars
                .Include(c => c.Model)
                .ThenInclude(m => m.Brand)
                .Include(c => c.CarReservationPricings)
                .ThenInclude(cr => cr.PricingPlan);

            return rentalPricings;
        }
    }
}
