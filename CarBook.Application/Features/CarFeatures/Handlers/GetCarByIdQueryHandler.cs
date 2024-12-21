using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
        {
            var car = await _repository.GetByIdAsync(getCarByIdQuery.Id);
            return new()
            {
                Id = car.Id,
                ModelId = car.ModelId,
                BigImageUrl = car.BigImageUrl,
                CoverImageUrl = car.CoverImageUrl,
                FuelType = car.FuelType,
                Km = car.Km,
                Luggage = car.Luggage,
                SeatCount = car.SeatCount,
                TransmissionType = car.TransmissionType
            };
        }
    }
}
