using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

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
            var blogComment = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogComment).Name, request.Id.ToString());

            await _repository.DeleteAsync(blogComment);
        }
    }
}
