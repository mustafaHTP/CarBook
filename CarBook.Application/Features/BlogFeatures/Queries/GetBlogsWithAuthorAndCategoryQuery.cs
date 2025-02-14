using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogsWithAuthorAndCategoryQuery : IRequest<List<GetBlogsWithAuthorAndCategoryQueryResult>>
    {
    }
}
