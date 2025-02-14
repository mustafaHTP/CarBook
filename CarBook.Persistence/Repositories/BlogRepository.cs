using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public List<Blog> GetAllWithAuthorAndCategory()
        {
            return [.. _context.Blogs.Include(b => b.BlogAuthor).Include(b => b.BlogCategory)];
        }

        public Blog GetByIdWithAuthor(int id)
        {
            return _context.Blogs.Include(b => b.BlogAuthor).FirstOrDefault(b => b.Id == id);
        }

        public List<Blog> GetLast3BlogsWithAuthorAndCategory()
        {
            return _context.Set<Blog>().Include(b => b.BlogAuthor).Include(b => b.BlogCategory).OrderByDescending(b => b.Id).Take(3).ToList();
        }
    }
}
