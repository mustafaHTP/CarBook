using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById(request.Id, request.Includes);
            var result = new GetBlogByIdQueryResult()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Content = blog.Content,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                BlogAuthorId = blog.BlogAuthorId,
                BlogAuthor = blog.BlogAuthor,
                BlogCategoryId = blog.BlogCategoryId,
                BlogCategory = blog.BlogCategory
            };

            return await Task.FromResult(result);
        }
    }
}
