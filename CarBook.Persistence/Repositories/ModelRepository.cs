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
