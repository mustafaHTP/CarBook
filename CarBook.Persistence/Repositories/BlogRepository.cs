﻿using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistence.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
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

        public Blog? GetById(int id, IEnumerable<Expression<Func<Blog, object?>>> includes)
        {
            var blogs = _context.Blogs.AsQueryable();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    blogs = blogs.Include(include);
                }
            }

            var blog = blogs.SingleOrDefault(b => b.Id == id);

            return blog;
        }

        public int GetCommentCountById(int id)
        {
            return _context.BlogComments
                .Where(bc => bc.BlogId == id)
                .Count();
        }
    }
}
