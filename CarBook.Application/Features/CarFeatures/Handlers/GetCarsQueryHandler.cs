using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<GetCarsQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsQueryResult>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = _repository.GetAll();
            var result = cars.Select(c => new GetCarsQueryResult()
            {
                Id = c.Id,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
