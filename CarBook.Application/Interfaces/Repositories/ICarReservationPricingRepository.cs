using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface ICarReservationPricingRepository : IRepository<CarReservationPricing>
    {
        IEnumerable<CarReservationPricing> GetAll(IEnumerable<string>? rentalPeriods);
        List<CarReservationPricing> GetAllWithCarAndPricePlan();
        List<CarReservationPricing> GetAllWithCarAndDayPricePlan();
    }
}
