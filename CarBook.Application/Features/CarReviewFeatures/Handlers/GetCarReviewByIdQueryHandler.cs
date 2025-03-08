using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarReviewFeatures.Queries;
using CarBook.Application.Features.CarReviewFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Handlers
{
    public class GetCarReviewByIdQueryHandler : IRequestHandler<GetCarReviewByIdQuery, GetCarReviewByIdQueryResult>
    {
        private readonly IRepository<CarReview> _repository;

        public GetCarReviewByIdQueryHandler(IRepository<CarReview> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarReviewByIdQueryResult> Handle(GetCarReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var carReview = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(CarReview), request.Id);
            var result = new GetCarReviewByIdQueryResult
            {
                Id = carReview.Id,
                CarId = carReview.CarId,
                CustomerId = carReview.CustomerId,
                Review = carReview.Review,
                ReviewDate = carReview.ReviewDate,
                RatingStarCount = carReview.RatingStarCount
            };

            return await Task.FromResult(result);
        }
    }
}
