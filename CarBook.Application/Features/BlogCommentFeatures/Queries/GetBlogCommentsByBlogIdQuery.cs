using CarBook.Application.Features.BlogCommentFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Queries
{
    public class GetBlogCommentsByBlogIdQuery : IRequest<List<GetBlogCommentsByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }
    }
}
