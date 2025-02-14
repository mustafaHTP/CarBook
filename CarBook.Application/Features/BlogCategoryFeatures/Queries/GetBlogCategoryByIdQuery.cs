using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogCategoryByIdQuery : IRequest<GetBlogCategoryByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
