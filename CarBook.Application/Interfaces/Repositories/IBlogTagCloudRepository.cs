using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IBlogTagCloudRepository : IRepository<BlogTagCloud>
    {
        IEnumerable<BlogTagCloud> GetAllByBlogIdWithBlogTag(int blogId);
    }
}
