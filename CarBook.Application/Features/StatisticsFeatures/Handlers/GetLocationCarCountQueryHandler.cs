using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetLocationCarCountQueryHandler : IRequestHandler<GetLocationCarCountQuery, IEnumerable<GetLocationCarCountQueryResult>>
    {
        private readonly IStatisticsRepository _repository;

        public GetLocationCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<GetLocationCarCountQueryResult>> Handle(GetLocationCarCountQuery request, CancellationToken cancellationToken)
        {
            var locationCarCount = _repository.GetLocationCarCount();
            var result = locationCarCount.Select(l => new GetLocationCarCountQueryResult
            {
                LocationName = l.Name,
                CarCount = l.RentalCars?.Count ?? 0
            });

            return Task.FromResult(result);
        }
    }
}
