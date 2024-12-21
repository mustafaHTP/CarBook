using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetAllCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetAllCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllCarQueryResult>> Handle()
        {
            var cars = await _repository.GetAllAsync();
            return cars.Select(c => new GetAllCarQueryResult()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType
            }).ToList();
        }
    }
}
