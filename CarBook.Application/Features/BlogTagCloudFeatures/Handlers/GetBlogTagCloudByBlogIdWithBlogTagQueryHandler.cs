using CarBook.Application.Features.BlogTagCloudFeatures.Queries;
using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Handlers
{
    internal class GetBlogTagCloudByBlogIdWithBlogTagQueryHandler : IRequestHandler<GetBlogTagCloudByBlogIdWithBlogTagQuery, List<GetBlogTagCloudByBlogIdWithBlogTagQueryResult>>
    {
        private readonly IBlogTagCloudRepository _repository;

        public GetBlogTagCloudByBlogIdWithBlogTagQueryHandler(IBlogTagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogTagCloudByBlogIdWithBlogTagQueryResult>> Handle(GetBlogTagCloudByBlogIdWithBlogTagQuery request, CancellationToken cancellationToken)
        {
            var blogTagClouds = _repository.GetAllByBlogIdWithBlogTag(request.BlogId);
            var result = blogTagClouds.Select(x => new GetBlogTagCloudByBlogIdWithBlogTagQueryResult
            {
                Id = x.Id,
                BlogId = x.BlogId,
                BlogTag = x.BlogTag,
                BlogTagId = x.BlogTagId
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
