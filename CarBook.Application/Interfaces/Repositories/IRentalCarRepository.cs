using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IRentalCarRepository : IRepository<RentalCar>
    {
        Task<IEnumerable<RentalCar>> GetAllByFilterAsync(int? pickUpLocationId);
    }
}
