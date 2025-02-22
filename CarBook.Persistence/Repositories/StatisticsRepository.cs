using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
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
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationDbContext _context;

        public StatisticsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal GetAverageCarRentalPrice(IEnumerable<string> rentalPeriods)
        {
            var carReservationPricings = _context.CarReservationPricings.AsQueryable();

            // If no rental periods are provided, calculate the average price of all car reservation pricings
            if (!rentalPeriods.Any())
            {
                return carReservationPricings.Any() 
                    ? carReservationPricings.Average(crp => crp.Price) 
                    : 0m;
            }

            // Generate a dictionary of rental periods and their corresponding IDs
            var rentalPeriodIds = _context.PricingPlans
                .Where(pp => rentalPeriods.Contains(pp.Name.ToLower()))
                .Select(pp => pp.Id)
                .ToList();

            // Filter car reservation pricings by rental periods
            var filteredCarReservationPricings = carReservationPricings
                .Where(crp => rentalPeriodIds.Contains(crp.PricingPlanId));

            return filteredCarReservationPricings.Any()
                ? filteredCarReservationPricings.Average(crp => crp.Price)
                : 0m;
        }

        public int GetBlogCommentCountByBlogId(int blogId)
        {
            return _context
                .BlogComments
                .Where(bc => bc.BlogId == blogId)
                .Count();
        }

        public Blog? GetBlogHasMaxCommentCount()
        {
            var blogHasMaxCommentCount = _context.Blogs.Include(b => b.BlogComments).OrderByDescending(b => b.BlogComments.Count).FirstOrDefault();

            return blogHasMaxCommentCount;
        }

        public Brand? GetBrandHasMaxModelCount()
        {
            var brandHasMaxModelCount = _context.Brands.Include(b => b.Models).OrderByDescending(b => b.Models.Count).FirstOrDefault();

            return brandHasMaxModelCount;
        }

        public int GetCarCountByDistance(int distanceKm, bool countLessThan)
        {
            Expression<Func<Car, bool>> expression = countLessThan
                ? c => c.Km <= distanceKm
                : c => c.Km >= distanceKm;

            return _context.Cars.Where(expression).Count();
        }

        public int GetCarCountByFuelType(IEnumerable<FuelType?> fuelTypes)
        {
            return _context.Cars.Count(c => fuelTypes.Contains(c.FuelType));
        }

        public int GetCarCountByTransmissionType(IEnumerable<TransmissionType?> transmissionTypes)
        {
            return _context.Cars.Count(c => transmissionTypes.Contains(c.TransmissionType));
        }
    }
}
