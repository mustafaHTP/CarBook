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
    public class GetBlogTagCloudsQueryHandler : IRequestHandler<GetBlogTagCloudsQuery, List<GetBlogTagCloudsQueryResult>>
    {
        private readonly IRepository<BlogTagCloud> _repository;

        public GetBlogTagCloudsQueryHandler(IRepository<BlogTagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogTagCloudsQueryResult>> Handle(GetBlogTagCloudsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAllAsync();
            var result = blogs.Select(x => new GetBlogTagCloudsQueryResult
            {
                Id = x.Id,
                BlogId = x.BlogId,
                BlogTagId = x.BlogTagId
            }).ToList();

            return result;
        }
    }
}
