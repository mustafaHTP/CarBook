using CarBook.Application.Features.FooterAddressFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Queries
{
    public class GetFooterAddressesQuery : IRequest<List<GetFooterAddressesQueryResult>>
    {
    }
}
