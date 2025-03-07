using CarBook.Application.Interfaces.Repositories;
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

        public IEnumerable<Blog> GetAll(IEnumerable<Expression<Func<Blog, object?>>> includes, int limit = 0, bool isDescendingOrder = false)
        {
            var blogs = _context.Blogs.AsQueryable();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    blogs = blogs.Include(include);
                }
            }

            if (isDescendingOrder)
            {
                blogs = blogs.OrderByDescending(b => b.Id);
            }

            if (limit > 0)
            {
                blogs = blogs.Take(limit);
            }

            return blogs;
        }

        public IEnumerable<Blog> GetAllByBlogCategoryId(int blogCategoryId, IEnumerable<Expression<Func<Blog, object?>>> includes)
        {
            var blogs = _context.Blogs.AsQueryable();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    blogs = blogs.Include(include);
                }
            }

            return blogs.Where(b => b.BlogCategoryId == blogCategoryId);
        }

        public List<Blog> GetAllWithAuthorAndCategory()
        {
            return [.. _context.Blogs.Include(b => b.BlogAuthor).Include(b => b.BlogCategory)];
        }

        public int GetBlogsCountByBlogCategoryId(int blogCategoryId)
        {
            return _context.Blogs.Count(b => b.BlogCategoryId == blogCategoryId);
        }

        public IEnumerable<BlogTag> GetBlogTagsById(int id)
        {
            return _context.BlogTagClouds
                .Include(bt => bt.BlogTag)
                .Where(bt => bt.BlogId == id)
                .Select(bt => bt.BlogTag);
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

        public int GetCommentCountById(int id)
        {
            return _context.BlogComments
                .Where(bc => bc.BlogId == id)
                .Count();
        }

        public List<Blog> GetLast3BlogsWithAuthorAndCategory()
        {
            return _context.Set<Blog>().Include(b => b.BlogAuthor).Include(b => b.BlogCategory).OrderByDescending(b => b.Id).Take(3).ToList();
        }
    }
}
