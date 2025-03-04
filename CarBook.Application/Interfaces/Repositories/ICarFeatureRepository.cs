using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface ICarFeatureRepository : IRepository<CarFeature>
    {
        Task AddCarFeatureToAllCarsAsync(int featureId);
    }
}
