using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarDescriptionsByCarIdQueryHandler : IRequestHandler<GetCarDescriptionsByCarIdQuery, IEnumerable<GetCarDescriptionsByCarIdQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarDescriptionsByCarIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarDescriptionsByCarIdQueryResult>> Handle(GetCarDescriptionsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carDescriptions = _repository.GetCarDescriptionsByCarId(request.CarId);
            var result = carDescriptions.Select(cd => new GetCarDescriptionsByCarIdQueryResult
            {
                CarDescriptionId = cd.Id,
                CarId = cd.CarId,
                Description = cd.Description
            });

            return await Task.FromResult(result);
        }
    }
}
