﻿using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetCarCountByFuelTypeQuery : IRequest<GetCarCountByFuelTypeQueryResult>
    {
        public string? FuelTypes { get; set; }
    }
}
