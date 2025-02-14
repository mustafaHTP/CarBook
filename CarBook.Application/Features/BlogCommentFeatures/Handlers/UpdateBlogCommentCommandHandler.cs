﻿using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class UpdateBlogCommentCommandHandler : IRequestHandler<UpdateBlogCommentCommand>
    {
        private readonly IRepository<BlogComment> _repository;

        public UpdateBlogCommentCommandHandler(IRepository<BlogComment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommentCommand request, CancellationToken cancellationToken)
        {
            var blogComment = await _repository.GetByIdAsync(request.Id);

            // Update here
            blogComment.Name = request.Name;
            blogComment.Content = request.Content;

            await _repository.UpdateAsync(blogComment);
        }
    }
}
