using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Model> GetAll(bool IncludeBrand, bool IncludeCars)
        {
            var models = _context.Models.AsQueryable();

            models = IncludeBrand ? models.Include(x => x.Brand) : models;
            models = IncludeCars ? models.Include(x => x.Cars) : models;

            return [.. models];
        }
    }
}
