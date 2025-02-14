using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Application.Features.BlogCommentFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class GetBlogCommentsByBlogIdQueryHandler : IRequestHandler<GetBlogCommentsByBlogIdQuery, List<GetBlogCommentsByBlogIdQueryResult>>
    {
        private readonly IBlogCommentRepository _repository;

        public GetBlogCommentsByBlogIdQueryHandler(IBlogCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogCommentsByBlogIdQueryResult>> Handle(GetBlogCommentsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var blogComments = _repository.GetAllByBlogId(request.BlogId);
            var result = blogComments.Select(x => new GetBlogCommentsByBlogIdQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Content = x.Content,
                BlogId = x.BlogId
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
