using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
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
