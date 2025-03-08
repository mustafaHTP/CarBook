using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogTagCloudFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Handlers
{
    public class DeleteBlogTagCloudCommandHandler : IRequestHandler<DeleteBlogTagCloudCommand>
    {
        private readonly IRepository<BlogTagCloud> _repository;

        public DeleteBlogTagCloudCommandHandler(IRepository<BlogTagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogTagCloudCommand request, CancellationToken cancellationToken)
        {
            var blogTagCloud = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogTagCloud).Name, request.Id.ToString());

            await _repository.DeleteAsync(blogTagCloud);
        }
    }
}
