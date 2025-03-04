using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetBlogCommentCountByBlogIdQuery : IRequest<GetBlogCommentCountByBlogIdQueryResult>
    {
        public int BlogId { get; set; }
    }
}
