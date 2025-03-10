using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogCommentRepository : IRepository<BlogComment>
    {
        IEnumerable<BlogComment> GetAllByBlogId(int blogId);
        BlogComment? GetById(int id);
    }
}
