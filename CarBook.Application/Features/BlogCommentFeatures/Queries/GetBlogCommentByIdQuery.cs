using CarBook.Application.Features.BlogCommentFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Queries
{
    public class GetBlogCommentByIdQuery : IRequest<GetBlogCommentByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
