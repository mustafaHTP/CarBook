using CarBook.Application.Features.BlogAuthorFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Queries
{
    public class GetBlogAuthorByIdQuery : IRequest<GetBlogAuthorByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
