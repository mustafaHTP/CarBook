using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog GetByIdWithAuthor(int id);
        List<Blog> GetAllWithAuthorAndCategory();
        List<Blog> GetLast3BlogsWithAuthorAndCategory();
    }
}
