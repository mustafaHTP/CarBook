using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogCategoriesQueryHandler : IRequestHandler<GetBlogCategoriesQuery, List<GetBlogCategoriesQueryResult>>
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetBlogCategoriesQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogCategoriesQueryResult>> Handle(GetBlogCategoriesQuery request, CancellationToken cancellationToken)
        {
            var blogCategories = await _repository.GetAllAsync();

            return blogCategories.Select(b => new GetBlogCategoriesQueryResult()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }
    }
}
