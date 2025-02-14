using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBlogTagRepository : IRepository<BlogTag>
    {
        List<BlogTag> GetLastN(int count);
    }
}
