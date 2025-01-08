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

        public List<Car> GetAllCarsWithBrand()
        {
            return [.. _context.Cars.Include( c => c.Model)];
        }

        public List<Car> GetAll(GetCarsQuery getCarsQuery)
        {
            var carsQuery = _context.Cars.AsQueryable();

            if (getCarsQuery.IncludeBrand)
            {
                carsQuery = carsQuery.Include(c => c.Model).ThenInclude(m => m.Brand);

            }
            else if (getCarsQuery.IncludeModel)  // Only include Brand without Model
            {
                // Include Brand directly in case Model is not included
                carsQuery = carsQuery.Include(c => c.Model);
            }

            return carsQuery.ToList();
        }
    }
}
