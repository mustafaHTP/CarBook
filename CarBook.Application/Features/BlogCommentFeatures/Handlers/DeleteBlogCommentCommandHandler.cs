using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class DeleteBlogCommentCommandHandler : IRequestHandler<DeleteBlogCommentCommand>
    {
        private readonly IRepository<BlogComment> _repository;

        public DeleteBlogCommentCommandHandler(IRepository<BlogComment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogCommentCommand request, CancellationToken cancellationToken)
        {
            var blogComment = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(blogComment);
        }
    }
}
