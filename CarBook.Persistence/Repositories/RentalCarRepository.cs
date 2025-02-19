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

        public async Task<IEnumerable<RentalCar>> GetAllByFilterAsync(Expression<Func<RentalCar, bool>> filter)
        {
            return await _context
                .RentalCars
                .Include(rc => rc.Location)
                .Include(rc => rc.Car)
                .Where(filter).ToListAsync();
        }
    }
}
