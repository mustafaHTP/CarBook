using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog? GetById(int id, IEnumerable<string> includes);
        IEnumerable<Blog> GetAll(IEnumerable<string> includes);
        Blog GetByIdWithAuthor(int id);
        List<Blog> GetAllWithAuthorAndCategory();
        List<Blog> GetLast3BlogsWithAuthorAndCategory();
    }
}
