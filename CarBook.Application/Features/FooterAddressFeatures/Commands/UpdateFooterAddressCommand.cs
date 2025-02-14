using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Commands
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
