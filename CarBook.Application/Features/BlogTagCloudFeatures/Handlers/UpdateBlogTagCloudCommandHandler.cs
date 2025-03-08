using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogTagCloudFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Handlers
{
    public class UpdateBlogTagCloudCommandHandler : IRequestHandler<UpdateBlogTagCloudCommand>
    {
        private readonly IRepository<BlogTagCloud> _repository;

        public UpdateBlogTagCloudCommandHandler(IRepository<BlogTagCloud> repository)
        {
            _repository = repository;
        }


        public async Task Handle(UpdateBlogTagCloudCommand request, CancellationToken cancellationToken)
        {
            var blogTagCloud = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogTagCloud), request.Id);

            // Update here
            blogTagCloud.BlogId = request.BlogId;
            blogTagCloud.BlogTagId = request.BlogTagId;

            await _repository.UpdateAsync(blogTagCloud);
        }
    }
}
