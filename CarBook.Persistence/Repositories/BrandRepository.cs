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
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Brand>> GetAllAsync(bool includeModels)
        {
            var brands = _context.Brands.AsQueryable();

            if (includeModels)
            {
                brands = brands.Include(b => b.Models);
            }

            return await brands.ToListAsync();
        }
    }
}
