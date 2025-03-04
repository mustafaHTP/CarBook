using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class BlogAuthorRepository : Repository<BlogAuthor>, IBlogAuthorRepository
    {
        public BlogAuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BlogAuthor> GetAll(bool includeModels)
        {
            var blogAuthors = _context.BlogAuthors.AsQueryable();

            if (includeModels)
            {
                blogAuthors = blogAuthors.Include(x => x.Blogs);
            }

            return [.. blogAuthors];
        }
    }
}
