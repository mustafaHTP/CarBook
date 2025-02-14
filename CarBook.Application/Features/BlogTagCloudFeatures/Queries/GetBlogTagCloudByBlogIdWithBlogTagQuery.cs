using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Queries
{
    public class GetBlogTagCloudByBlogIdWithBlogTagQuery : IRequest<List<GetBlogTagCloudByBlogIdWithBlogTagQueryResult>>
    {
        public int BlogId { get; set; }
    }
}
