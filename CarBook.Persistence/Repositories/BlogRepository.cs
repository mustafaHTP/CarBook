using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistence.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private static readonly Dictionary<string, Expression<Func<Blog, object>>> _includeMappings =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "author", b => b.BlogAuthor },
                { "category", b => b.BlogCategory },
            };

        public BlogRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IEnumerable<Blog> GetAll(IEnumerable<string> includes)
        {
            var blogs = _context.Blogs.AsQueryable();

            if (includes.Any())
            {
                //Normalize the includes and ensure they are unique
                var uniqueIncludes = new HashSet<string>(includes.Select(i => i.ToLower()));

                foreach (var item in uniqueIncludes)
                {
                    if (_includeMappings.TryGetValue(item, out Expression<Func<Blog, object>>? value))
                    {
                        blogs = blogs.Include(value);
                    }
                }
            }

            return blogs;
        }

        public List<Blog> GetAllWithAuthorAndCategory()
        {
            return [.. _context.Blogs.Include(b => b.BlogAuthor).Include(b => b.BlogCategory)];
        }

        public Blog? GetById(int id, IEnumerable<string> includes)
        {
            var blogs = _context.Blogs.AsQueryable();

            if (includes.Any())
            {
                //Normalize the includes and ensure they are unique
                var uniqueIncludes = new HashSet<string>(includes.Select(i => i.ToLower()));

                foreach (var item in uniqueIncludes)
                {
                    if (_includeMappings.TryGetValue(item, out Expression<Func<Blog, object>>? value))
                    {
                        blogs = blogs.Include(value);
                    }
                }
            }

            var blog = blogs.SingleOrDefault(b => b.Id == id);

            return blog;
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
