using CarBook.Application.Features.BlogCommentFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Queries
{
    public class GetBlogCommentsQuery : IRequest<List<GetBlogCommentsQueryResult>>
    {
    }
}
