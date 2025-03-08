using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Commands
{
    public class CreateAboutCommand : IRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
