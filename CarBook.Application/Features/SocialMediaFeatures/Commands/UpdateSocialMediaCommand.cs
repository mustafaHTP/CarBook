using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Commands
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
