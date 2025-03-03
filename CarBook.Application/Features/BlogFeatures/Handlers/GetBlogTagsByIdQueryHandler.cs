using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogTagsByIdQueryHandler : IRequestHandler<GetBlogTagsByIdQuery, IEnumerable<GetBlogTagsByIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogTagsByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<GetBlogTagsByIdQueryResult>> Handle(GetBlogTagsByIdQuery request, CancellationToken cancellationToken)
        {
            var blogTags = _repository.GetBlogTagsById(request.Id);
            var result = blogTags.Select(x => new GetBlogTagsByIdQueryResult()
            {
                Id = x.Id,
                Name = x.Name
            });

            return Task.FromResult(result);
        }
    }
}
