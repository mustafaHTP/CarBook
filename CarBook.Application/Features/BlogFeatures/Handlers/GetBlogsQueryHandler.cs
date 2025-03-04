using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, IEnumerable<GetBlogsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = _repository.GetAll(request.Includes, request.Limit, request.DescendingOrder);
            var result = blogs.Select(blog => new GetBlogsQueryResult
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Description = blog.Description,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                BlogAuthorId = blog.BlogAuthorId,
                BlogAuthor = blog.BlogAuthor,
                BlogCategoryId = blog.BlogCategoryId,
                BlogCategory = blog.BlogCategory
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
