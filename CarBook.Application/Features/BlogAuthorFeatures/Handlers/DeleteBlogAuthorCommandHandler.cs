using CarBook.Application.Features.BlogAuthorFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Handlers
{
    public class DeleteBlogAuthorCommandHandler : IRequestHandler<DeleteBlogAuthorCommand>
    {
        private readonly IRepository<BlogAuthor> _repository;

        public DeleteBlogAuthorCommandHandler(IRepository<BlogAuthor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogAuthorCommand request, CancellationToken cancellationToken)
        {
            var blogAuthor = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(blogAuthor);
        }
    }
}
