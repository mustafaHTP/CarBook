﻿using CarBook.Application.Interfaces;
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

        public Car? GetById(int id, bool includeModel, bool includeBrand)
        {
            var cars = _context.Cars.AsQueryable();

            if (includeBrand)
            {
                cars = cars.Include(c => c.Model).ThenInclude(m => m.Brand);
            }
            else if (includeModel)
            {
                cars = cars.Include(c => c.Model);
            }

            return cars.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CarFeature> GetCarFeaturesByCarId(int carId)
        {
            return _context.CarFeatures.Where(cf => cf.CarId == carId).Include(cf => cf.Feature);
        }

        public IEnumerable<Car> GetAll(bool includeModel, bool includeBrand)
        {
            var cars = _context.Set<Car>().AsQueryable();

            if (includeBrand)
            {
                cars = cars
                    .Include(c => c.Model)
                    .ThenInclude(m => m.Brand);
            }
            else if (includeModel)
            {
                cars = cars
                    .Include(c => c.Model);
            }

            return cars;
        }
    }
}
