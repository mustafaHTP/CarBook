using CarBook.Application.Features.FooterAddressFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Queries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
