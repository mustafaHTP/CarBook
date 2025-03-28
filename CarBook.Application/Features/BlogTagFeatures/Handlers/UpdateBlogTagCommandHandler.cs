﻿using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class UpdateBlogTagCommandHandler : IRequestHandler<UpdateBlogTagCommand>
    {
        private readonly IRepository<BlogTag> _repository;

        public UpdateBlogTagCommandHandler(IRepository<BlogTag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogTagCommand request, CancellationToken cancellationToken)
        {
            var blogTag = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(BlogTag), request.Id.ToString());

            // Update here
            blogTag.Name = request.Name;

            await _repository.UpdateAsync(blogTag);
        }
    }
}
