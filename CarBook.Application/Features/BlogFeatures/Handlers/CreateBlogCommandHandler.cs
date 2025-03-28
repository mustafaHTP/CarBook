﻿using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                BlogAuthorId = request.BlogAuthorId,
                BlogCategoryId = request.BlogCategoryId,
                Title = request.Title,
                Content = request.Content,
                Description = request.Description,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now,
            };

            await _repository.CreateAsync(blog);
        }
    }
}
