using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarReviewFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarReviewFeatures.Handlers
{
    public class DeleteCarReviewCommandHandler : IRequestHandler<DeleteCarReviewCommand>
    {
        private readonly IRepository<CarReview> _repository;

        public DeleteCarReviewCommandHandler(IRepository<CarReview> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCarReviewCommand request, CancellationToken cancellationToken)
        {
            var carReview = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(CarReview).Name, request.Id.ToString());
            await _repository.DeleteAsync(carReview);
        }
    }
}
