using CarBook.Application.Features.LocationFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Queries
{
    public class GetLocationsQuery : IRequest<List<GetLocationsQueryResult>>
    {
    }
}
