using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
