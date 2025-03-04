using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogCommentCountByIdQuery : IRequest<GetBlogCommentCountByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
