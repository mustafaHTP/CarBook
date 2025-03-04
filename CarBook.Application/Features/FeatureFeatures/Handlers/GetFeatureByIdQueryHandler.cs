using CarBook.Application.Features.CarFeatureFeatures.Results;
using CarBook.Application.Features.FeatureFeatures.Queries;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Handlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);

            return new GetFeatureByIdQueryResult()
            {
                Id = feature.Id,
                Name = feature.Name,
            };
        }
    }
}
