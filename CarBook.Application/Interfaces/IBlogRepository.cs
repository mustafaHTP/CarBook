using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog GetByIdWithAuthor(int id);
        List<Blog> GetAllWithAuthorAndCategory();
        List<Blog> GetLast3BlogsWithAuthorAndCategory();
    }
}
