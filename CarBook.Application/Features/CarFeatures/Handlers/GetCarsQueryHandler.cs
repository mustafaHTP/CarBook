using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<GetCarsQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsQueryResult>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = _repository.GetAll(request);
            return cars.Select(c => new GetCarsQueryResult()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BrandId = c.Model.BrandId,
                Brand = c.Model.Brand,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType
            }).ToList();
        }

        //public async Task<List<GetCarsQueryResult>> HandleAsync(GetCarsQuery getCarsQuery)
        //{
        //    var cars = _repository.GetAll(getCarsQuery);
        //    return cars.Select(c => new GetCarsQueryResult()
        //    {
        //        Id = c.Id,
        //        ModelId = c.ModelId,
        //        Model = c.Model,
        //        BrandId = c.Model.BrandId,
        //        Brand = c.Model.Brand,
        //        BigImageUrl = c.BigImageUrl,
        //        CoverImageUrl = c.CoverImageUrl,
        //        FuelType = c.FuelType,
        //        Km = c.Km,
        //        Luggage = c.Luggage,
        //        SeatCount = c.SeatCount,
        //        TransmissionType = c.TransmissionType
        //    }).ToList();
        //}
    }
}
