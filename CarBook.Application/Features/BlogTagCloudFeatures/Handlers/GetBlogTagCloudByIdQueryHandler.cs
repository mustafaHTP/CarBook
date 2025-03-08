using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogTagCloudFeatures.Queries;
using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Handlers
{
    public class GetBlogTagCloudByIdQueryHandler : IRequestHandler<GetBlogTagCloudByIdQuery, GetBlogTagCloudByIdQueryResult>
    {
        private readonly IRepository<BlogTagCloud> _repository;

        public GetBlogTagCloudByIdQueryHandler(IRepository<BlogTagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTagCloudByIdQueryResult> Handle(GetBlogTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var blogTagCloud = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogTagCloud).Name, request.Id.ToString());
            var result = new GetBlogTagCloudByIdQueryResult
            {
                Id = blogTagCloud.Id,
                BlogId = blogTagCloud.BlogId,
                BlogTagId = blogTagCloud.BlogTagId
            };

            return result;
        }
    }
}
