using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories
{
    public class BlogTagRepository : Repository<BlogTag>, IBlogTagRepository
    {
        public BlogTagRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BlogTag> GetLastN(int count)
        {
            return [.. _context.BlogTags.OrderByDescending(bt => bt.Id).Take(count)];
        }
    }
}
