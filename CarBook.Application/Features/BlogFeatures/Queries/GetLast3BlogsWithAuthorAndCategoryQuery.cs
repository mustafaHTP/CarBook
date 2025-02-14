using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetLast3BlogsWithAuthorAndCategoryQuery : IRequest<List<GetLast3BlogsWithAuthorAndCategoryQueryResult>>
    {
    }
}
