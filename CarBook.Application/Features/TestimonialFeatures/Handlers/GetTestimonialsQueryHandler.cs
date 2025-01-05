﻿using CarBook.Application.Features.TestimonialFeatures.Queries;
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
    public class GetTestimonialsQueryHandler : IRequestHandler<GetTestimonialsQuery, List<GetTestimonialsQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialsQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetTestimonialsQueryResult>> Handle(GetTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var testimonials = await _repository.GetAllAsync();

            return testimonials.Select(testimonial => new GetTestimonialsQueryResult
            {
                Id = testimonial.Id,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            }).ToList();
        }
    }
}
