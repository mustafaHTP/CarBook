using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<BlogTag> GetBlogTagsById(int id);
        int GetCommentCountById(int id);
        Blog? GetById(int id, IEnumerable<string> includes);
        IEnumerable<Blog> GetAll(IEnumerable<string> includes, int limit, bool isDescendingOrder);
        Blog GetByIdWithAuthor(int id);
        List<Blog> GetAllWithAuthorAndCategory();
        List<Blog> GetLast3BlogsWithAuthorAndCategory();
    }
}
