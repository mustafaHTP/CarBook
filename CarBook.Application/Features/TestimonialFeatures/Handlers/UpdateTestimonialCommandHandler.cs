using CarBook.Application.Exceptions;
using CarBook.Application.Features.TestimonialFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Handlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Testimonial>(request.Id);

            testimonial.Name = request.Name;
            testimonial.Comment = request.Comment;
            testimonial.ImageUrl = request.ImageUrl;
            testimonial.Title = request.Title;

            await _repository.UpdateAsync(testimonial);

        }
    }
}
