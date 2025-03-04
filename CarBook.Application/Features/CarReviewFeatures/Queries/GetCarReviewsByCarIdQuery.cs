using CarBook.Application.Features.CarReviewFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Queries
{
    public class GetCarReviewsByCarIdQuery : IRequest<IEnumerable<GetCarReviewsByCarIdQueryResult>>
    {
        public int CarId { get; set; }
    }
}
