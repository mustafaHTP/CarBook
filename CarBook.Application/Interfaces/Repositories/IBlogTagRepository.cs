using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogTagRepository : IRepository<BlogTag>
    {
        IEnumerable<BlogTag> GetLastN(int count);
    }
}
