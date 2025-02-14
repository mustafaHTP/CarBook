using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<List<Brand>> GetAllAsync(bool includeModels);
    }
}
