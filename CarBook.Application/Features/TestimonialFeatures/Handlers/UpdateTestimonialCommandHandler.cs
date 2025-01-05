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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonialToBeUpdated = await _repository.GetByIdAsync(request.Id);

            testimonialToBeUpdated.Name = request.Name;
            testimonialToBeUpdated.Comment = request.Comment;
            testimonialToBeUpdated.ImageUrl = request.ImageUrl;
            testimonialToBeUpdated.Title = request.Title;

            await _repository.UpdateAsync(testimonialToBeUpdated);

        }
    }
}
