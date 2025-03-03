using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogsQuery : IRequest<IEnumerable<GetBlogsQueryResult>>
    {
        public List<string> Includes { get; set; } = [];
        public int Limit { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
