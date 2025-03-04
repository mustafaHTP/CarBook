using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class CarReviewRepository : Repository<CarReview>, ICarReviewRepository
    {
        public CarReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<CarReview> GetAllByCarId(int carId)
        {
            return _context.CarReviews
                .Include(cr => cr.Customer)
                .Where(cr => cr.CarId == carId);
        }
    }
}
