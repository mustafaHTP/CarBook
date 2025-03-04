using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogTagsByIdQuery : IRequest<IEnumerable<GetBlogTagsByIdQueryResult>>
    {
        public int Id { get; set; }
    }
}
