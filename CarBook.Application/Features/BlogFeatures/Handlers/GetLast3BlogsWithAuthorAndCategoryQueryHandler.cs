using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetLast3BlogsWithAuthorAndCategoryQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorAndCategoryQuery, List<GetLast3BlogsWithAuthorAndCategoryQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsWithAuthorAndCategoryQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorAndCategoryQueryResult>> Handle(GetLast3BlogsWithAuthorAndCategoryQuery request, CancellationToken cancellationToken)
        {
            var blogs = _repository.GetLast3BlogsWithAuthorAndCategory();
            var result = blogs.Select(b => new GetLast3BlogsWithAuthorAndCategoryQueryResult()
            {
                Id = b.Id,
                BlogAuthorId = b.BlogAuthorId,
                BlogAuthor = b.BlogAuthor,
                BlogCategoryId = b.BlogCategoryId,
                BlogCategory = b.BlogCategory,
                Title = b.Title,
                Content = b.Content,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
