using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBrandHasMaxModelCountQueryHandler : IRequestHandler<GetBrandHasMaxModelCountQuery, GetBrandHasMaxModelCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandHasMaxModelCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public Task<GetBrandHasMaxModelCountQueryResult> Handle(GetBrandHasMaxModelCountQuery request, CancellationToken cancellationToken)
        {
            var brand = _repository.GetBrandHasMaxModelCount();
            var result = new GetBrandHasMaxModelCountQueryResult
            {
                BrandName = brand?.Name,
                ModelCount = brand?.Models.Count ?? 0
            };

            return Task.FromResult(result);
        }
    }
}
