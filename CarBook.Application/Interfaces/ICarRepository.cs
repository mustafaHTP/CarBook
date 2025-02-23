using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<CarFeature> GetCarFeaturesByCarId(int carId);
        Car? GetById(int id, bool includeModel, bool includeBrand);
        List<Car> GetCarsWithReservationPricings();
        List<Car> GetLast5CarsWithBrand();
        List<Car> GetAllCarsWithModel();
        List<Car> GetAllCarsWithBrand();
        List<Car> GetAll();
    }
}
