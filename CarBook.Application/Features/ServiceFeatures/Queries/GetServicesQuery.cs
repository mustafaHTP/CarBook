using CarBook.Application.Features.ServiceFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Queries
{
    public class GetServicesQuery : IRequest<List<GetServicesQueryResult>>
    {
    }
}
