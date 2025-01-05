using CarBook.Application.Features.TestimonialFeatures.Queries;
using CarBook.Application.Features.TestimonialFeatures.Results;
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
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.Id);

            return new GetTestimonialByIdQueryResult
            {
                Id = testimonial.Id,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            };
        }
    }
}
