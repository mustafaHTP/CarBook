using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogByIdWithAuthorQuery : IRequest<GetBlogByIdWithAuthorQueryResult>
    {
        public int Id { get; set; }
    }
}
