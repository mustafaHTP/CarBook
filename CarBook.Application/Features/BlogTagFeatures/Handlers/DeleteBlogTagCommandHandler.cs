using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class DeleteBlogTagCommandHandler : IRequestHandler<DeleteBlogTagCommand>
    {
        private readonly IRepository<BlogTag> _repository;

        public DeleteBlogTagCommandHandler(IRepository<BlogTag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogTagCommand request, CancellationToken cancellationToken)
        {
            var blogTag = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(blogTag);
        }
    }
}
