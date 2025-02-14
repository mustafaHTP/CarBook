using CarBook.Application.Features.BlogTagFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Queries
{
    public class GetBlogTagByIdQuery : IRequest<GetBlogTagByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
