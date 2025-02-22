using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface ICarReservationPricingRepository : IRepository<CarReservationPricing>
    {
        IEnumerable<CarReservationPricing> GetAll(IEnumerable<string>? rentalPeriods);
        List<CarReservationPricing> GetAllWithCarAndPricePlan();
        List<CarReservationPricing> GetAllWithCarAndDayPricePlan();
    }
}
