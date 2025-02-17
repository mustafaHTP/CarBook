using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetCarCountByFuelTypeQuery : IRequest<GetCarCountByFuelTypeQueryResult>
    {
        public string? FuelTypes { get; set; }
    }
}
