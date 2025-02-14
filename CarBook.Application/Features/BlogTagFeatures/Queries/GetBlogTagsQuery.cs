using CarBook.Application.Features.BlogTagFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Queries
{
    public class GetBlogTagsQuery : IRequest<List<GetBlogTagsQueryResult>>
    {
    }
}
