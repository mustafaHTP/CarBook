using CarBook.Application.Features.TestimonialFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var testimonialToBeCreated = new Testimonial() 
            { 
                Name = request.Name,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Title = request.Title
            };

            await _repository.CreateAsync(testimonialToBeCreated);
        }
    }
}
