using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        List<Car> GetCarsWithReservationPricings();
        List<Car> GetLast5CarsWithBrand();
        List<Car> GetAllCarsWithModel();
        List<Car> GetAllCarsWithBrand();
        List<Car> GetAll();
    }
}
