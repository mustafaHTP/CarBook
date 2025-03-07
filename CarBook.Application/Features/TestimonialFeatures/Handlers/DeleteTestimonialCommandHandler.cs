using CarBook.Application.Exceptions;
using CarBook.Application.Features.TestimonialFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Handlers
{
    public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public DeleteTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Testimonial>(request.Id);

            await _repository.DeleteAsync(testimonial);
        }
    }
}
