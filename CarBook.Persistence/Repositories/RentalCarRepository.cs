using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class RentalCarRepository : Repository<RentalCar>, IRentalCarRepository
    {
        public RentalCarRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<RentalCar>> GetAllByFilterAsync(int? pickUpLocationId)
        {
            var rentalCars = _context.RentalCars
                .Include(rc => rc.Car)
                .ThenInclude(rc => rc.Model)
                .ThenInclude(rc => rc.Brand)
                .Include(rc => rc.Location)
                .Where(rc => rc.LocationId == pickUpLocationId);

            return Task.FromResult(rentalCars.AsEnumerable());
        }
    }
}
