using CarBook.Application.Features.BlogAuthorFeatures.Queries;
using CarBook.Application.Features.BlogAuthorFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Handlers
{
    public class GetBlogAuthorsQueryHandler : IRequestHandler<GetBlogAuthorsQuery, List<GetBlogAuthorsQueryResult>>
    {
        private readonly IBlogAuthorRepository _repository;

        public GetBlogAuthorsQueryHandler(IBlogAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogAuthorsQueryResult>> Handle(GetBlogAuthorsQuery request, CancellationToken cancellationToken)
        {
            var blogAuthors = _repository.GetAll(request.IncludeBlogs);
            var result = blogAuthors.Select(x => new GetBlogAuthorsQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Blogs = x.Blogs
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
