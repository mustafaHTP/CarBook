using CarBook.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        int GetBlogsCountByBlogCategoryId(int blogCategoryId);
        IEnumerable<Blog> GetAllByBlogCategoryId(int blogCategoryId, IEnumerable<Expression<Func<Blog, object?>>> includes);
        IEnumerable<BlogTag> GetBlogTagsById(int id);
        int GetCommentCountById(int id);
        Blog? GetById(int id, IEnumerable<string> includes);
        IEnumerable<Blog> GetAll(IEnumerable<Expression<Func<Blog, object?>>> includes, int limit, bool isDescendingOrder);
        Blog GetByIdWithAuthor(int id);
        List<Blog> GetAllWithAuthorAndCategory();
        List<Blog> GetLast3BlogsWithAuthorAndCategory();
    }
}
