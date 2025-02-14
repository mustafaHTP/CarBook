using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Queries
{
    public class GetBlogTagCloudsQuery : IRequest<List<GetBlogTagCloudsQueryResult>>
    {
    }
}
