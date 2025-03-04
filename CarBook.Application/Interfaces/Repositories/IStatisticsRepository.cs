using CarBook.Domain.Entities;
using CarBook.Domain.Enums;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IStatisticsRepository
    {
        int GetCarReviewsCountByCarId(int carId);
        IEnumerable<Brand> GetAllBrands();
        int GetBlogCommentCountByBlogId(int blogId);
        int GetCarCountByDistance(int distanceKm, bool countLessThan);
        int GetCarCountByTransmissionType(IEnumerable<TransmissionType?> transmissionTypes);
        int GetCarCountByFuelType(IEnumerable<FuelType?> fuelTypes);
        Blog? GetBlogHasMaxCommentCount();
        Brand? GetBrandHasMaxModelCount();
        decimal GetAverageCarRentalPrice(IEnumerable<string> rentalPeriods);
    }
}
