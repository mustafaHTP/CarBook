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
    public class BlogCommentRepository : Repository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BlogComment> GetAllByBlogId(int blogId)
        {
            return [.. _context.BlogComments.Where(bc => bc.BlogId == blogId)];
        }
    }
}
