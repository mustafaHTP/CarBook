using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Brand>> GetAllAsync(bool includeModels)
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
