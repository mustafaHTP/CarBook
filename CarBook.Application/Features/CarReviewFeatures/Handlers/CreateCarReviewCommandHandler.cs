using CarBook.Application.Features.CarReviewFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Handlers
{
    public class CreateCarReviewCommandHandler : IRequestHandler<CreateCarReviewCommand>
    {
        private readonly IRepository<CarReview> _repository;

        public CreateCarReviewCommandHandler(IRepository<CarReview> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarReviewCommand request, CancellationToken cancellationToken)
        {
            var carReview = new CarReview
            {
                CarId = request.CarId,
                CustomerId = request.CustomerId,
                Review = request.Review,
                ReviewDate = request.ReviewDate,
                RatingStarCount = request.RatingStarCount
            };
            await _repository.CreateAsync(carReview);
        }
    }
}
