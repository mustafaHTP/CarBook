using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);

            return new GetBlogByIdQueryResult
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
            };
        }
    }
}
