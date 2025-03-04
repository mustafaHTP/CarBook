using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandCountQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var count = _repository.Count();
            var result = new GetBrandCountQueryResult
            {
                BrandCount = count
            };

            return Task.FromResult(result);
        }
    }
}
