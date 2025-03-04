using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarFeaturesByCarIdQueryHandler : IRequestHandler<GetCarFeaturesByCarIdQuery, IEnumerable<GetCarFeaturesByCarIdQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarFeaturesByCarIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<GetCarFeaturesByCarIdQueryResult>> Handle(GetCarFeaturesByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carFeatures = _repository.GetCarFeaturesByCarId(request.CarId);
            var result = carFeatures.Select(cf => new GetCarFeaturesByCarIdQueryResult()
            {
                CarFeatureId = cf.Id,
                CarId = cf.CarId,
                Car = cf.Car,
                FeatureId = cf.FeatureId,
                Feature = cf.Feature,
                IsAvailable = cf.Available
            });

            return Task.FromResult(result);
        }
    }
}
