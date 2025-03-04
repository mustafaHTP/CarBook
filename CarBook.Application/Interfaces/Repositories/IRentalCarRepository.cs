using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IRentalCarRepository : IRepository<RentalCar>
    {
        Task<IEnumerable<RentalCar>> GetAllByFilterAsync(int? pickUpLocationId);
    }
}
