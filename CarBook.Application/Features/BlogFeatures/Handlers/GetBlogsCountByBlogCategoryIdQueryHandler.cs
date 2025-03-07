using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogsCountByBlogCategoryIdQueryHandler : IRequestHandler<GetBlogsCountByBlogCategoryIdQuery, GetBlogsCountByBlogCategoryIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsCountByBlogCategoryIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<GetBlogsCountByBlogCategoryIdQueryResult> Handle(GetBlogsCountByBlogCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var count = _repository.GetBlogsCountByBlogCategoryId(request.BlogCategoryId);
            var result = new GetBlogsCountByBlogCategoryIdQueryResult
            {
                Count = count
            };

            return Task.FromResult(result);
        }
    }
}
