using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogCommentRepository : IRepository<BlogComment>
    {
        List<BlogComment> GetAllByBlogId(int blogId);
    }
}
