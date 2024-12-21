using CarBook.Application.Features.CarFeatures.Commands;
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
    public class GetAllCarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetAllCarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }


        public List<GetAllCarsWithBrandQueryResult> Handle()
        {
            return _repository.GetAllCarsWithBrand().Select(c => new GetAllCarsWithBrandQueryResult()
            {
                Id = c.Id,
                ModelName = c.Model.Name,
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
