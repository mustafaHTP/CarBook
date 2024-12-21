using CarBook.Application.Features.FeatureFeatures.Queries;
using CarBook.Application.Features.FeatureFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FeatureFeatures.Handlers
{
    public class GetAllFeaturesQueryHandler : IRequestHandler<GetAllFeaturesQuery, List<GetAllFeaturesQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetAllFeaturesQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllFeaturesQueryResult>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();
            return features.Select(f => new GetAllFeaturesQueryResult()
            {
                Id = f.Id,
                Name = f.Name,
            }).ToList();
        }
    }
}
