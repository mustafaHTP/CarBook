using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetCarCountByTransmissionTypeQueryHandler : IRequestHandler<GetCarCountByTransmissionTypeQuery, GetCarCountByTransmissionTypeQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        private readonly IRepository<Car> _carRepository;

        public GetCarCountByTransmissionTypeQueryHandler(IStatisticsRepository repository, IRepository<Car> carRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
        }

        public Task<GetCarCountByTransmissionTypeQueryResult> Handle(GetCarCountByTransmissionTypeQuery request, CancellationToken cancellationToken)
        {
            var transmissionTypes = request
                .TransmissionTypes?
                .Split(',')
                .Select(x => Enum.TryParse<TransmissionType>(x, true, out TransmissionType transmissionType) ? transmissionType : (TransmissionType?)null).ToList();

            var result = new GetCarCountByTransmissionTypeQueryResult
            {
                CarCount = transmissionTypes != null
                    ? _repository.GetCarCountByTransmissionType(transmissionTypes)
                    : _carRepository.Count()
            };

            return Task.FromResult(result);
        }
    }
}
