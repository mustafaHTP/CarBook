using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetCarReviewCountByCarIdQueryHandler : IRequestHandler<GetCarReviewCountByCarIdQuery, GetCarReviewCountByCarIdQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarReviewCountByCarIdQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarReviewCountByCarIdQueryResult> Handle(GetCarReviewCountByCarIdQuery request, CancellationToken cancellationToken)
        {
            int carReviewsCount = _repository.GetCarReviewsCountByCarId(request.CarId);
            var result = new GetCarReviewCountByCarIdQueryResult
            {
                CarReviewCount = carReviewsCount
            };

            return await Task.FromResult(result);
        }
    }
}
