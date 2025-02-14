using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBlogCommentRepository : IRepository<BlogComment>
    {
        List<BlogComment> GetAllByBlogId(int blogId);
    }
}
