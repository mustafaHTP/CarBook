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

        public List<Model> GetAll(bool IncludeCars)
        {
            var models = _context.Models.AsQueryable();

            models = IncludeCars ? models.Include(x => x.Cars) : models;

            return [.. models];
        }
    }
}
