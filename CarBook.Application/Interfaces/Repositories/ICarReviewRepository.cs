using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface ICarReviewRepository : IRepository<CarReview>
    {
        IEnumerable<CarReview> GetAllByCarId(int carId);
    }
}
