using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class BlogCommentRepository : Repository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<BlogComment> GetAllByBlogId(int blogId)
        {
            return [.. _context.BlogComments.Where(bc => bc.BlogId == blogId)];
        }
    }
}
