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
    public class GetBlogsWithAuthorAndCategoryQueryHandler : IRequestHandler<GetBlogsWithAuthorAndCategoryQuery, List<GetBlogsWithAuthorAndCategoryQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsWithAuthorAndCategoryQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogsWithAuthorAndCategoryQueryResult>> Handle(GetBlogsWithAuthorAndCategoryQuery request, CancellationToken cancellationToken)
        {
            var blogs = _repository.GetAllWithAuthorAndCategory();
            var result = blogs.Select(b => new GetBlogsWithAuthorAndCategoryQueryResult()
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                Description = b.Description,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate,
                BlogAuthorId = b.BlogAuthorId,
                BlogAuthorName = b.BlogAuthor.Name,
                BlogCategoryId = b.BlogCategoryId,
                BlogCategoryName = b.BlogCategory.Name
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
