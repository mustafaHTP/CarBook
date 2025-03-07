using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogAuthorRepository : IRepository<BlogAuthor>
    {
        IEnumerable<BlogAuthor> GetAll(bool includeModels);
    }
}
