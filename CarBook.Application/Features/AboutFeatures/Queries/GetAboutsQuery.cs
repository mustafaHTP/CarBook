using CarBook.Application.Features.AboutFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Queries
{
    public class GetAboutsQuery : IRequest<List<GetAboutsQueryResult>>
    {
    }
}
