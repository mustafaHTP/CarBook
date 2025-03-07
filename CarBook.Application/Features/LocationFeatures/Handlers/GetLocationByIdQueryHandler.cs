using CarBook.Application.Exceptions;
using CarBook.Application.Features.LocationFeatures.Queries;
using CarBook.Application.Features.LocationFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Handlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Location>(request.Id);

            return new GetLocationByIdQueryResult
            {
                Id = location.Id,
                Name = location.Name
            };
        }
    }
}
