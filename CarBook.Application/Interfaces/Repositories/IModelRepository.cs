using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IModelRepository : IRepository<Model>
    {
        List<Model> GetAll(bool IncludeCars);
        Model? GetById(int id);
    }
}
