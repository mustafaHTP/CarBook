using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Commands
{
    public class DeleteFooterAddressCommand : IRequest
    {
        public int Id { get; set; }
    }
}
