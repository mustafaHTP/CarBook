using CarBook.Application.Features.BlogTagCloudFeatures.Queries;
using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var blogTagCloud = await _repository.GetByIdAsync(request.Id);
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
