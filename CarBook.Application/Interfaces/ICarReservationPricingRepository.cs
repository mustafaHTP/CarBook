using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface ICarReservationPricingRepository : IRepository<CarReservationPricing>
    {
        List<CarReservationPricing> GetAllWithCarAndPricePlan();
        List<CarReservationPricing> GetAllWithCarAndDayPricePlan();
    }
}
