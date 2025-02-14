using CarBook.Application.Features.FeatureFeatures.Queries;
using CarBook.Application.Features.FeatureFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Handlers
{
    public class GetFeaturesQueryHandler : IRequestHandler<GetAllFeaturesQuery, List<GetFeaturesQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeaturesQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeaturesQueryResult>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();
            return features.Select(f => new GetFeaturesQueryResult()
            {
                Id = f.Id,
                Name = f.Name,
            }).ToList();
        }
    }
}
