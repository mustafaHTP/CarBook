using CarBook.Application.Features.BlogCategoryFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Queries
{
    public class GetBlogCategoryByIdQuery : IRequest<GetBlogCategoryByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
