using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogTagRepository : IRepository<BlogTag>
    {
        List<BlogTag> GetLastN(int count);
    }
}
