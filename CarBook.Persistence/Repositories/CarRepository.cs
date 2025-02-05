using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarBook.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Car> GetAllCarsWithModel()
        {
            return [.. _context.Cars.Include( c => c.Model)];
        }

        public List<Car> GetAll()
        {
            return [.. _context.Cars];
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
    }
}
