using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarsWithBrandQueryHandler : IRequestHandler<GetCarsWithBrandQuery, List<GetCarsWithBrandQueryResult>>
    {
        private ICarRepository _repository;

        public GetCarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsWithBrandQueryResult>> Handle(GetCarsWithBrandQuery request, CancellationToken cancellationToken)
        {
            var cars = _repository.GetAllCarsWithBrand();
            var result = cars.Select(c => new GetCarsWithBrandQueryResult()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BrandId = c.Model.BrandId,
                Brand = c.Model.Brand,
                Km = c.Km,
                SeatCount = c.SeatCount,
                Luggage = c.Luggage,
                TransmissionType = c.TransmissionType,
                FuelType = c.FuelType,
                CoverImageUrl = c.CoverImageUrl,
                BigImageUrl = c.BigImageUrl
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
