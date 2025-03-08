using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Commands
{
    public class CreateServiceCommand : IRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }
}
