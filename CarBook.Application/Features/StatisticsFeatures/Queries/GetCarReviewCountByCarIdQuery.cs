using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetCarReviewCountByCarIdQuery : IRequest<GetCarReviewCountByCarIdQueryResult>
    {
        public int CarId { get; set; }
    }
}
