using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
