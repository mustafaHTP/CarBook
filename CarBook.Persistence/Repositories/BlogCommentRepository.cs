using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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

        public BlogComment? GetById(int id)
        {
            return _context.BlogComments
                .Include(bc => bc.Blog)
                .FirstOrDefault(bc => bc.Id == id);
        }
    }
}
