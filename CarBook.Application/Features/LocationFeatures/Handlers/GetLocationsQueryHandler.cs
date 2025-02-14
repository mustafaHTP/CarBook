using CarBook.Application.Features.LocationFeatures.Queries;
using CarBook.Application.Features.LocationFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Handlers
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, List<GetLocationsQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationsQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationsQueryResult>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllAsync();

            return locations.Select(l => new GetLocationsQueryResult()
            {
                Id = l.Id,
                Name = l.Name,
            }).ToList();
        }
    }
}
