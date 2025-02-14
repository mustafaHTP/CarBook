using CarBook.Application.Features.BlogTagFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Queries
{
    public class GetLastNBlogTagsQuery : IRequest<List<GetLastNBlogTagsQueryResult>>
    {
        public int Count { get; set; }
    }
}
