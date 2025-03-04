using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<List<Brand>> GetAllAsync(bool includeModels);
    }
}
