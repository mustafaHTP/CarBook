using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Commands
{
    public class UpdateServiceCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }
}
