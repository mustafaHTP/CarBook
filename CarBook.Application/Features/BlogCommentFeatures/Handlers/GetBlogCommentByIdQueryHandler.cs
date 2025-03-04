using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Application.Features.BlogCommentFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class GetBlogCommentByIdQueryHandler : IRequestHandler<GetBlogCommentByIdQuery, GetBlogCommentByIdQueryResult>
    {
        private readonly IRepository<BlogComment> _repository;

        public GetBlogCommentByIdQueryHandler(IRepository<BlogComment> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCommentByIdQueryResult> Handle(GetBlogCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var blogComment = await _repository.GetByIdAsync(request.Id);

            return new GetBlogCommentByIdQueryResult
            {
                Id = blogComment.Id,
                Name = blogComment.Name,
                Email = blogComment.Email,
                CreatedDate = blogComment.CreatedDate,
                Content = blogComment.Content,
                BlogId = blogComment.BlogId
            };
        }
    }
}
