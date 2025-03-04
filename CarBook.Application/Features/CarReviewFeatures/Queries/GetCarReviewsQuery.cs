using CarBook.Application.Features.CarReviewFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Queries
{
    public class GetCarReviewsQuery : IRequest<IEnumerable<GetCarReviewsQueryResult>>
    {
    }
}
