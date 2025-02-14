using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces
{
    public interface IBlogTagCloudRepository : IRepository<BlogTagCloud>
    {
        List<BlogTagCloud> GetAllByBlogIdWithBlogTag(int blogId);
    }
}
