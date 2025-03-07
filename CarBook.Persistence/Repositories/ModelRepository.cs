using CarBook.Application.Interfaces.Repositories;
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

        public IEnumerable<Model> GetAll(bool IncludeCars)
        {
            var models = _context.Models
                .Include(m => m.Brand)
                .AsQueryable();

            models = IncludeCars ? models.Include(x => x.Cars) : models;

            return [.. models];
        }

        public Model? GetById(int id)
        {
            return _context.Models
                .Include(m => m.Brand)
                .SingleOrDefault(m => m.Id == id);
        }
    }
}
