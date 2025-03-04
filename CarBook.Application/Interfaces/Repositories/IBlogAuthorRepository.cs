using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogAuthorRepository : IRepository<BlogAuthor>
    {
        List<BlogAuthor> GetAll(bool includeModels);
    }
}
