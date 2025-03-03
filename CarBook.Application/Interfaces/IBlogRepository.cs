using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        int GetCommentCountById(int id);
        Blog? GetById(int id, IEnumerable<string> includes);
        IEnumerable<Blog> GetAll(IEnumerable<string> includes, int limit, bool isDescendingOrder);
        Blog GetByIdWithAuthor(int id);
        List<Blog> GetAllWithAuthorAndCategory();
        List<Blog> GetLast3BlogsWithAuthorAndCategory();
    }
}
