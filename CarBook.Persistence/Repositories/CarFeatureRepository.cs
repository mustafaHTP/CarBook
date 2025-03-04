using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class CarFeatureRepository : Repository<CarFeature>, ICarFeatureRepository
    {
        public CarFeatureRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddCarFeatureToAllCarsAsync(int featureId)
        {
            await _context.Cars.ForEachAsync(car =>
            {
                var carFeature = new CarFeature
                {
                    CarId = car.Id,
                    FeatureId = featureId,
                    Available = false
                };
                _context.CarFeatures.Add(carFeature);
            });

            _context.SaveChanges();
        }
    }
}
