using CarBook.Application.Features.BlogTagFeatures.Queries;
using CarBook.Application.Features.BlogTagFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class GetLastNBlogTagsQueryHandler : IRequestHandler<GetLastNBlogTagsQuery, List<GetLastNBlogTagsQueryResult>>
    {
        private readonly IBlogTagRepository _repository;

        public GetLastNBlogTagsQueryHandler(IBlogTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastNBlogTagsQueryResult>> Handle(GetLastNBlogTagsQuery request, CancellationToken cancellationToken)
        {
            var blogTags = _repository.GetLastN(request.Count);
            var result = blogTags.Select(x => new GetLastNBlogTagsQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
