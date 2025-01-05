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
    public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public DeleteTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonialToBeDeleted = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(testimonialToBeDeleted);
        }
    }
}
