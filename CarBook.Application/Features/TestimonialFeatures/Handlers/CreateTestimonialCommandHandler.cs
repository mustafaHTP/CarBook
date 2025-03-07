using CarBook.Application.Features.TestimonialFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.TestimonialFeatures.Handlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = new Testimonial()
            {
                Name = request.Name,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Title = request.Title
            };

            await _repository.CreateAsync(testimonial);
        }
    }
}
