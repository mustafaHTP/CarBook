﻿using CarBook.Application.Features.RentalCarFeatures.Queries;
using CarBook.Application.Features.RentalCarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RentalCarFeatures.Handlers
{
    public class GetRentalCarsQueryHandler : IRequestHandler<GetRentalCarsQuery, IEnumerable<GetRentalCarsQueryResult>>
    {
        private readonly IRentalCarRepository _repository;

        public GetRentalCarsQueryHandler(IRentalCarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetRentalCarsQueryResult>> Handle(GetRentalCarsQuery request, CancellationToken cancellationToken)
        {
            var rentalCars = await _repository.GetAllByFilterAsync(rc => rc.LocationId == request.LocationId);
            var result = rentalCars.Select(rc => new GetRentalCarsQueryResult
            {
                LocationId = rc.LocationId,
                Location = rc.Location,
                CarId = rc.CarId,
                Car = rc.Car,
                IsAvailable = rc.IsAvailable
            });

            return result;
        }
    }
}
