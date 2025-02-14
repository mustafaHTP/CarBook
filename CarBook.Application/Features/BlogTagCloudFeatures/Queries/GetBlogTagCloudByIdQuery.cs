using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Queries
{
    public class GetBlogTagCloudByIdQuery : IRequest<GetBlogTagCloudByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
