using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
    {
        public int Id { get; set; }
        public List<string> Includes { get; set; } = [];
    }
}
