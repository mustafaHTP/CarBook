using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        public IEnumerable<Car> GetAllWithRentalPricings();
        IEnumerable<CarReservationPricing> GetCarRentalPricingsByCarId(int carId);
        IEnumerable<CarDescription> GetCarDescriptionsByCarId(int carId);
        IEnumerable<CarFeature> GetCarFeaturesByCarId(int carId);
        Car? GetById(int id);
        List<Car> GetCarsWithReservationPricings();
        List<Car> GetLast5CarsWithBrand();
        List<Car> GetAllCarsWithModel();
        List<Car> GetAllCarsWithBrand();
        IEnumerable<Car> GetAll();
    }
}
