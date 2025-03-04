using CarBook.Application.Features.BlogTagFeatures.Queries;
using CarBook.Application.Features.BlogTagFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class GetBlogTagByIdQueryHandler : IRequestHandler<GetBlogTagByIdQuery, GetBlogTagByIdQueryResult>
    {
        private readonly IRepository<BlogTag> _repository;

        public GetBlogTagByIdQueryHandler(IRepository<BlogTag> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTagByIdQueryResult> Handle(GetBlogTagByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);

            return new GetBlogTagByIdQueryResult
            {
                Id = blog.Id,
                Name = blog.Name
            };
        }
    }
}
