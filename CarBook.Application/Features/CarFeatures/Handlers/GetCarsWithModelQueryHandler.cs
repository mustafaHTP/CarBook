using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarsWithModelQueryHandler : IRequestHandler<GetCarsWithModelQuery, List<GetCarsWithModelQueryResult>>
    {
        private ICarRepository _repository;

        public GetCarsWithModelQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetCarsWithModelQueryResult>> Handle(GetCarsWithModelQuery request, CancellationToken cancellationToken)
        {
            var cars = _repository.GetAllCarsWithModel();
            return Task.FromResult(cars.Select(c => new GetCarsWithModelQueryResult()
            {
                Id = c.Id,
                Model = c.Model,
                ModelId = c.ModelId,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType
            }).ToList());
        }
    }
}
