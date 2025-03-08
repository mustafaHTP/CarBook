using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Commands
{
    public class UpdateAboutCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
