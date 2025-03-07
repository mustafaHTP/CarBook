using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarReviewFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Handlers
{
    public class UpdateCarReviewCommandHandler : IRequestHandler<UpdateCarReviewCommand>
    {
        private readonly IRepository<CarReview> _repository;

        public UpdateCarReviewCommandHandler(IRepository<CarReview> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarReviewCommand request, CancellationToken cancellationToken)
        {
            var carReview = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<CarReview>(request.Id);

            // Update here
            carReview.Review = request.Review;
            carReview.RatingStarCount = request.RatingStarCount;
            carReview.ReviewDate = request.ReviewDate;

            await _repository.UpdateAsync(carReview);
        }
    }
}
