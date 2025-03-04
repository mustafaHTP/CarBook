using CarBook.Application.Features.CarReviewFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Queries
{
    public class GetCarReviewByIdQuery : IRequest<GetCarReviewByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
