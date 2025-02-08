using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class BlogTagCloudRepository : Repository<BlogTagCloud>, IBlogTagCloudRepository
    {
        public BlogTagCloudRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BlogTagCloud> GetAllByBlogIdWithBlogTag(int blogId)
        {
            return [.. _context.BlogTagClouds.Include(btc => btc.BlogTag).Where(btc => btc.BlogId == blogId)];
        }
    }
}
