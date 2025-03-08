using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Commands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
