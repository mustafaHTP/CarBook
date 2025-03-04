using CarBook.Application.Features.RentalCarFeatures.Queries;
using CarBook.Application.Features.RentalCarFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.RentalCarFeatures.Handlers
{
    public class GetRentalCarsQueryHandler : IRequestHandler<GetRentalCarsQuery, IEnumerable<GetRentalCarsQueryResult>>
    {
        private readonly IRentalCarRepository _repository;

        public GetRentalCarsQueryHandler(IRentalCarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetRentalCarsQueryResult>> Handle(GetRentalCarsQuery request, CancellationToken cancellationToken)
        {
            var rentalCars = await _repository.GetAllByFilterAsync(request.PickUpLocationId);
            var result = rentalCars.Select(rc => new GetRentalCarsQueryResult
            {
                Id = rc.Id,
                LocationId = rc.LocationId,
                Location = rc.Location,
                CarId = rc.CarId,
                Car = rc.Car,
                IsAvailable = rc.IsAvailable
            });

            return result;
        }
    }
}
