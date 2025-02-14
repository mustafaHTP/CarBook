using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IModelRepository : IRepository<Model>
    {
        List<Model> GetAll(bool IncludeBrand, bool IncludeCars);
    }
}
