﻿using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogCategoryByIdQueryHandler : IRequestHandler<GetBlogCategoryByIdQuery, GetBlogCategoryByIdQueryResult>
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetBlogCategoryByIdQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCategoryByIdQueryResult> Handle(GetBlogCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var blogCategory = await _repository.GetByIdAsync(request.Id);

            return new GetBlogCategoryByIdQueryResult()
            {
                Id = blogCategory.Id,
                Name = blogCategory.Name,
            };
        }
    }
}
