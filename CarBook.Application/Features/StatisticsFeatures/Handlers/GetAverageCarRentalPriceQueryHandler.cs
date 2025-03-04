using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetAverageCarRentalPriceQueryHandler : IRequestHandler<GetAverageCarRentalPriceQuery, GetAverageCarRentalPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAverageCarRentalPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public Task<GetAverageCarRentalPriceQueryResult> Handle(GetAverageCarRentalPriceQuery request, CancellationToken cancellationToken)
        {
            var averagePrice = _repository.GetAverageCarRentalPrice(request.RentalPeriods);
            var result = new GetAverageCarRentalPriceQueryResult
            {
                AveragePrice = averagePrice
            };

            return Task.FromResult(result);
        }
    }
}
