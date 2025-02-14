using CarBook.Application.Features.BlogAuthorFeatures.Queries;
using CarBook.Application.Features.BlogAuthorFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Handlers
{
    public class GetBlogAuthorsQueryHandler : IRequestHandler<GetBlogAuthorsQuery, List<GetBlogAuthorsQueryResult>>
    {
        private readonly IRepository<BlogAuthor> _repository;

        public GetBlogAuthorsQueryHandler(IRepository<BlogAuthor> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogAuthorsQueryResult>> Handle(GetBlogAuthorsQuery request, CancellationToken cancellationToken)
        {
            var blogAuthors = await _repository.GetAllAsync();

            return blogAuthors.Select(x => new GetBlogAuthorsQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
