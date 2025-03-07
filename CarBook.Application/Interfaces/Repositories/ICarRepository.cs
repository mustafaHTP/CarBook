using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllWithRentalPricings();
        IEnumerable<CarReservationPricing> GetCarRentalPricingsByCarId(int carId);
        IEnumerable<CarDescription> GetCarDescriptionsByCarId(int carId);
        IEnumerable<CarFeature> GetCarFeaturesByCarId(int carId);
        Car? GetById(int id);
        IEnumerable<Car> GetCarsWithReservationPricings();
        IEnumerable<Car> GetAll();
    }
}
