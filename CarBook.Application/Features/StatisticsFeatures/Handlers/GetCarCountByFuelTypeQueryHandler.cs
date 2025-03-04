using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetCarCountByFuelTypeQueryHandler : IRequestHandler<GetCarCountByFuelTypeQuery, GetCarCountByFuelTypeQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        private readonly IRepository<Car> _carRepository;

        public GetCarCountByFuelTypeQueryHandler(IStatisticsRepository repository, IRepository<Car> carRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
        }

        public Task<GetCarCountByFuelTypeQueryResult> Handle(GetCarCountByFuelTypeQuery request, CancellationToken cancellationToken)
        {
            var fuelTypes = request
                .FuelTypes?
                .Split(',')
                .Select(x => Enum.TryParse<FuelType>(x, true, out FuelType fuelType) ? fuelType : (FuelType?)null).ToList();

            var result = new GetCarCountByFuelTypeQueryResult
            {
                CarCount = fuelTypes != null
                    ? _repository.GetCarCountByFuelType(fuelTypes)
                    : _carRepository.Count()
            };

            return Task.FromResult(result);
        }
    }
}
