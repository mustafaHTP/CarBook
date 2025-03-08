using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Commands
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
