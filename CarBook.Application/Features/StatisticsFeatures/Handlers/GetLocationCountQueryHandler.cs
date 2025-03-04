using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationCountQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var count = _repository.Count();
            var result = new GetLocationCountQueryResult
            {
                LocationCount = count
            };

            return Task.FromResult(result);
        }
    }
}
