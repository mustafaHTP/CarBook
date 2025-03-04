using CarBook.Application.Features.BlogCategoryFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Queries
{
    public class GetBlogCategoriesQuery : IRequest<List<GetBlogCategoriesQueryResult>>
    {

    }
}
